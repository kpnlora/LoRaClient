using System.Net.Http;

namespace Kpn.LoRa.Client.Core.Extensions
{
	public static class HttpResponseMessageExtensions
	{
		public static void HandleResponseErrors(this HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				return;
			}

			string result = response.Content.ReadAsStringAsync().Result;
			throw new HttpRequestException($"Response code {response.StatusCode}: {result}");
		}
	}
}
