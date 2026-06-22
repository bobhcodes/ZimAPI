namespace ZimApi.WebApplication.Models;

public readonly record struct Book(
	string Id,
	Uri Uri,
	string Title,
	string Name,
	string? Flavor,
	DateOnly Date)
{
	public static explicit operator Book(entryType entry)
	{
		ArgumentNullException.ThrowIfNull(entry);
		ArgumentException.ThrowIfNullOrEmpty(entry.id);
		ArgumentNullException.ThrowIfNull(entry.link);
		ArgumentOutOfRangeException.ThrowIfEqual(entry.link.Length, 0);
		ArgumentException.ThrowIfNullOrEmpty(entry.title);
		ArgumentException.ThrowIfNullOrEmpty(entry.name);
		ArgumentOutOfRangeException.ThrowIfEqual(default, entry.updated);

		var href = entry.link
			.First(l => string.Equals("application/x-zim", l.type, StringComparison.OrdinalIgnoreCase))
			.href;

		return new(
			entry.id,
			new Uri(href, UriKind.Absolute),
			entry.title,
			entry.name,
			entry.flavour,
			DateOnly.FromDateTime(entry.updated));
	}
}
