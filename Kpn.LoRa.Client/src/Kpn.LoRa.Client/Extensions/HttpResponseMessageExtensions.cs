using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.Extensions
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
