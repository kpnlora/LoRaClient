﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = Kpn.LoRa.Client.Models.Customers;
using DeviceProfiles = Kpn.LoRa.Client.Models.DeviceProfiles;
using NetworkSubscriptions = Kpn.LoRa.Client.Models.NetworkSubscriptions;
using AppServerRoutingProfiles = Kpn.LoRa.Client.Models.AppServerRoutingProfiles;
using Devices = Kpn.LoRa.Client.Models.Devices;
using DeviceViewModel = Kpn.LoRa.Client.Models.DeviceViewModel;
using DeviceAddModel = Kpn.LoRa.Client.Models.DeviceAddModel;
using DeviceUpdateModel = Kpn.LoRa.Client.Models.DeviceUpdateModel;
using Alarms = Kpn.LoRa.Client.Models.Alarms;
using AppServerRoutingProfileUpdateModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileUpdateModel;
using AppServerRoutingProfileAddModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileAddModel;
using AppServerRoutingProfileViewModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileViewModel;
using Newtonsoft.Json;
using Kpn.LoRa.Client.Models.Devices;
using Kpn.LoRa.Client.Models.Alarms;
using Kpn.LoRa.Client.Models.DeviceViewModel;
using System.Net.Http;
using Kpn.LoRa.Client.Extensions;

namespace Kpn.LoRa.Client
{
    public class LoRaClient : ILoRaClient
    {

        private LoRaHttpClient _loRaHttpClient;
        private const string _restPath = "/thingpark/wireless/rest";

        public LoRaClient(string username, string password, string subscriberId, string baseAddress)
        {
            _loRaHttpClient = new LoRaHttpClient(baseAddress, username, password, subscriberId);
        }


        public LoRaHttpClient LoRaHttpClient { get { return _loRaHttpClient; } }

        public void Dispose()
        {
            _loRaHttpClient.Dispose();
        }

        public async Task<DeviceProfiles.DeviceProfiles> GetDeviceProfiles(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/deviceProfiles");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DeviceProfiles.DeviceProfiles>(result);
        }

        public async Task<Customers.Customers> GetCustomers()
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}/customers");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customers.Customers>(result);
        }

        public async Task<NetworkSubscriptions.NetworkSubscriptions> GetNetworkSubscriptions(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/networkSubscriptions");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NetworkSubscriptions.NetworkSubscriptions>(result);
        }
        
        public async Task<Alarms.Alarms> GetAlarms(string deviceHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{deviceHref}/alarms");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Alarms.Alarms>(result);
        }

        public async Task AckAlarmsForDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.PostAsync($"{deviceHref}/alarms/ack");
            response.HandleResponseErrors();
        }


        public async Task<DeviceViewModel.Device> GetDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{deviceHref}");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DeviceViewModel.Device>(result);
        }
        public async Task<Devices.Devices> GetDevices(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/devices");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Devices.Devices>(result);
        }

        public async Task<DeviceViewModel.Device> AddDevice(string subscriptionHref, DeviceAddModel.Device device)
        {
            var response = await _loRaHttpClient.PostJsonAsync($"{_restPath}{subscriptionHref}/devices", device);
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            var addedDevice = JsonConvert.DeserializeObject<DeviceViewModel.Device>(result);
            var locationHeader = response.Headers.GetValues("Location");
            addedDevice.href = locationHeader.Single();

            return addedDevice;
        }


        public async Task<DeviceViewModel.Device> UpdateDevice(string deviceHref, DeviceUpdateModel.Device device)
        {
            var response = await _loRaHttpClient.PutJsonAsync($"{deviceHref}", device);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DeviceViewModel.Device>(result);
        }

        public async Task RemoveDevice(string deviceHref)
        {
            var response = await _loRaHttpClient.DeleteAsync($"{deviceHref}");
            response.HandleResponseErrors();
        }

        public async Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> GetAppServerRoutingProfile(string appServersRoutingProfileHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{appServersRoutingProfileHref}");
            response.HandleResponseErrors();

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServerRoutingProfileViewModel.AppServersRoutingProfile>(result);
        }

        public async Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> AddAppServerRoutingProfile(string subscriptionHref, AppServerRoutingProfileAddModel.AppServersRoutingProfile appServersRoutingProfile)
        {
            var response = await _loRaHttpClient.PostJsonAsync($"{_restPath}{subscriptionHref}/appServersRoutingProfiles", appServersRoutingProfile);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            var profile = JsonConvert.DeserializeObject<AppServerRoutingProfileViewModel.AppServersRoutingProfile>(result);
            var locationHeader = response.Headers.GetValues("Location");
            profile.href = locationHeader.Single();
            return profile;
        }

        public async Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> UpdateAppServerRoutingProfile(string appServersRoutingProfileHref, AppServerRoutingProfileUpdateModel.AppServersRoutingProfile appServersRoutingProfile)
        {
            var response = await _loRaHttpClient.PutJsonAsync($"{appServersRoutingProfileHref}", appServersRoutingProfile);
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServerRoutingProfileViewModel.AppServersRoutingProfile>(result);
        }

        public async Task<AppServerRoutingProfiles.AppServersRoutingProfiles> GetAppServerRoutingProfiles(string subscriptionHref)
        {
            var response = await _loRaHttpClient.GetAsync($"{_restPath}{subscriptionHref}/appServersRoutingProfiles");
            response.HandleResponseErrors();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppServerRoutingProfiles.AppServersRoutingProfiles>(result);
        }

        public async Task RemoveAppServerRoutingProfile(string appServersRoutingProfileHref)
        {
            var response = await _loRaHttpClient.DeleteAsync($"{appServersRoutingProfileHref}");
            response.HandleResponseErrors();
        }


      
    }
}