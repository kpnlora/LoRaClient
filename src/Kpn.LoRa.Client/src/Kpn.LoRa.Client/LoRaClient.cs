using System.Linq;
using System.Threading.Tasks;

using Kpn.LoRa.Client.Core.Extensions;
using Kpn.LoRa.Client.Core.Models.Alarms;
using Kpn.LoRa.Client.Core.Models.AppServerRoutingProfiles;
using Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileViewModel;
using Kpn.LoRa.Client.Core.Models.Customers;
using Kpn.LoRa.Client.Core.Models.DeviceProfiles;
using Kpn.LoRa.Client.Core.Models.Devices;
using Kpn.LoRa.Client.Core.Models.DeviceViewModel;
using Kpn.LoRa.Client.Core.Models.NetworkSubscriptions;

using Newtonsoft.Json;


namespace Kpn.LoRa.Client.Core
{
    public class LoRaClient : ILoRaClient
    {
        #region Constants

        private const string _restPath = "/thingpark/wireless/rest";

        #endregion

        #region Fields

        private readonly LoRaHttpClient _loRaHttpClient;

        #endregion

        #region Constructors

        public LoRaClient(string username, string password, string subscriberId, string baseAddress)
        {
            _loRaHttpClient = new LoRaHttpClient(baseAddress, username, password, subscriberId);
        }

        #endregion

        #region Properties

        public LoRaHttpClient LoRaHttpClient
        {
            get
            {
                return _loRaHttpClient;
            }
        }

        #endregion

        #region ILoRaClient Members

        public void Dispose()
        {
            _loRaHttpClient.Dispose();
        }

        public async Task<DeviceProfiles> GetDeviceProfiles(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/deviceProfiles");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DeviceProfiles>(result);
        }

        public async Task<Customers> GetCustomers()
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}/customers");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customers>(result);
        }

        public async Task<NetworkSubscriptions> GetNetworkSubscriptions(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/networkSubscriptions");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NetworkSubscriptions>(result);
        }

        public async Task<Alarms> GetAlarms(string deviceHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{deviceHref}/alarms");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Alarms>(result);
        }

        public async Task AckAlarmsForDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.PostAsync($"{deviceHref}/alarms/ack");
            response.HandleResponseErrors();
        }

        public async Task<Device> GetDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{deviceHref}");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Device>(result);
        }

        public async Task<Devices> GetDevices(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/devices");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Devices>(result);
        }

        public async Task<Device> AddDevice(string subscriptionHref, Models.DeviceAddModel.Device device)
        {
            var response = await _loRaHttpClient.PostJsonAsync($"{_restPath}{subscriptionHref}/devices", device);
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            var addedDevice = JsonConvert.DeserializeObject<Device>(result);
            var locationHeader = response.Headers.GetValues("Location");
            addedDevice.href = locationHeader.Single();

            return addedDevice;
        }

        public async Task<Device> UpdateDevice(string deviceHref, Models.DeviceUpdateModel.Device device)
        {
            var response = await _loRaHttpClient.PutJsonAsync($"{deviceHref}", device);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Device>(result);
        }

        public async Task RemoveDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.DeleteAsync($"{deviceHref}");
            response.HandleResponseErrors();
        }

        public async Task<AppServersRoutingProfile> GetAppServerRoutingProfile(string appServersRoutingProfileHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{appServersRoutingProfileHref}");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServersRoutingProfile>(result);
        }

        public async Task<AppServersRoutingProfile> AddAppServerRoutingProfile(string subscriptionHref,
            Models.AppServerRoutingProfileAddModel.AppServersRoutingProfile appServersRoutingProfile)
        {
            var response =
                await
                    _loRaHttpClient.PostJsonAsync($"{_restPath}{subscriptionHref}/appServersRoutingProfiles",
                                                  appServersRoutingProfile);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            var profile = JsonConvert.DeserializeObject<AppServersRoutingProfile>(result);
            var locationHeader = response.Headers.GetValues("Location");
            profile.href = locationHeader.Single();
            return profile;
        }

        public async Task<AppServersRoutingProfile> UpdateAppServerRoutingProfile(string appServersRoutingProfileHref,
            Models.AppServerRoutingProfileUpdateModel.AppServersRoutingProfile appServersRoutingProfile)
        {
            var response = await _loRaHttpClient.PutJsonAsync($"{appServersRoutingProfileHref}", appServersRoutingProfile);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServersRoutingProfile>(result);
        }

        public async Task<AppServersRoutingProfiles> GetAppServerRoutingProfiles(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/appServersRoutingProfiles");
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServersRoutingProfiles>(result);
        }

        public async Task RemoveAppServerRoutingProfile(string appServersRoutingProfileHref)
        {
            var response = await _loRaHttpClient.DeleteAsync($"{appServersRoutingProfileHref}");
            response.HandleResponseErrors();
        }

        #endregion
    }
}