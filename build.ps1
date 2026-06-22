docker buildx build `
	--file '.\ZimApi.WebApplication\Dockerfile' `
	--platform 'linux/arm64,linux/amd64' `
	--pull `
	--push `
	--tag 'eassbhhtgu/zimapi:latest' `
	--tag 'eassbhhtgu/zimapi:1' `
	--tag 'eassbhhtgu/zimapi:1.2' `
	--tag 'eassbhhtgu/zimapi:1.2.0' `
	.\ZimApi.WebApplication\
