using Helpers.Zim.Clients.Concrete;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace ZimApi.Tests;

public class ClientTests
{
	[SuppressMessage("Usage", "xUnit1004:Test methods should not be skipped", Justification = "Calls third party")]
	[Theory(Skip = "Calls third party")]
	[InlineData("https://browse.library.kiwix.org", "confirmed=yes; filters=lang=eng")]
	public async Task Test(string baseAddress, string cookie)
	{
		// Arrange
		var handler = new HttpClientHandler { AllowAutoRedirect = false, };
		var errorHandler = new ErrorHandler(handler);
		var httpClient = new HttpClient(errorHandler)
		{
			BaseAddress = new Uri(baseAddress, UriKind.Absolute),
			DefaultRequestHeaders =
			{
				{ "Accept", "application/json; charset=utf-8" },
				{ "Cookie", cookie },
				{ "User-Agent", "Mozilla/5.0 (iPad; U; CPU OS 3_2_1 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Mobile/7B405" },
			},
		};

		var xmlSerializerFactory = new XmlSerializerFactory();
		var client = new ZimClient(httpClient, xmlSerializerFactory);

		// Act
		IReadOnlyCollection<entryType> entries = await client.GetEntriesAsync(TestContext.Current.CancellationToken)
			.ToArrayAsync(TestContext.Current.CancellationToken);

		// Assert
		Assert.NotEmpty(entries);
		Assert.DoesNotContain(default, entries);
		foreach (var entry in entries)
		{
			Assert.NotNull(entry.title);
			Assert.NotNull(entry.link);
			foreach (var link in entry.link)
			{
				Assert.NotNull(link);
				Assert.NotNull(link.href);
			}
		}
	}

	private class ErrorHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var response = await base.SendAsync(request, cancellationToken);
			if (response.IsSuccessStatusCode)
			{
				return response;
			}
			var content = await response.Content.ReadAsStringAsync(cancellationToken);
			throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {content}");
		}
	}
}
