using Microsoft.AspNetCore.Http;

namespace BookStore.Infrastructure
{
	public static class UrlExtensionsForCart
	{
		public	static string PathAndQuery(this HttpRequest request)
		{
			return request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
		}
	}
}
