using Kpn.LoRa.Client.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Kpn.LoRa.Client
{

    public class LoRaHttpClient : IDisposable
    {
        private HttpClient _httpClient;
        private CredentialCache _credentialCache;
        private CookieContainer _cookieContainer;
        private string _subscriberId;
        private string _accessCode;

        public LoRaHttpClient(string baseAddress, string username, string password, string subscriberId)
        {
            _subscriberId = subscriberId;
            _credentialCache = CreateCredentialCache(baseAddress, username, password);
            _cookieContainer = new CookieContainer();

            var handler = new HttpClientHandler
            {
                Credentials = _credentialCache,
                CookieContainer = _cookieContainer
            };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Login();
        }

        private async void Login()
        {
            var thingparkId = await GetThingparkId();
            _accessCode = await GetAccessCode(thingparkId);
        }

        private CredentialCache CreateCredentialCache(string baseAddress, string username, string password)
        {
            var cache = new CredentialCache();
            cache.Add(new Uri(baseAddress), "Digest", new NetworkCredential(username, password, string.Empty));

            return cache;
        }

        public async Task<string> GetThingparkId()
        {
            var response = _httpClient.GetAsync("/thingpark/smp/rest/admins/id").Result;
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            dynamic resultObject = JsonConvert.DeserializeObject(result);

            return resultObject.thingparkID.ToString();

        }

        public async Task<string> GetAccessCode(string thingparkId)
        {
            var accessCode = new Models.AccessCode
            {
                moduleID = "TPW_SUBS",
                subscriberID = _subscriberId
            };

            var response = PostJsonAsync($"/thingpark/smp/rest/admins/{thingparkId}/accessCode", accessCode).Result;
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            dynamic resultObj = JsonConvert.DeserializeObject(result);
            return resultObj.accessCode.ToString();
        }

       

        public Task<HttpResponseMessage> PostJsonAsync(string requestUri, object obj) =>
            _httpClient.PostAsync(AddAccessCodeToRequestUri(requestUri), ToJson(obj));

        public Task<HttpResponseMessage> PutJsonAsync(string requestUri, object obj) =>
            _httpClient.PutAsync(AddAccessCodeToRequestUri(requestUri), ToJson(obj));

        public Task<HttpResponseMessage> PostAsync(string requestUri) =>
         _httpClient.PostAsync(AddAccessCodeToRequestUri(requestUri), null);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri) =>
         _httpClient.DeleteAsync(AddAccessCodeToRequestUri(requestUri));

        public Task<HttpResponseMessage> GetAsync(string requestUri) =>
            _httpClient.GetAsync(AddAccessCodeToRequestUri(requestUri));


        private StringContent ToJson(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        private string AddAccessCodeToRequestUri(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(_accessCode))
            {
                return requestUri;
            }

            return $"{requestUri}{(requestUri.Contains("?") ? "&" : "?")}adminAccessCode={_accessCode}&type=SUBSCRIBER";
        }

        public HttpClient HttpClient { get { return _httpClient; } }

  
        public void Dispose()
        {
            _httpClient.GetAsync("/thingpark/wireless/rest/customers/logout");
            _httpClient.Dispose();
        }


    }
    
}
