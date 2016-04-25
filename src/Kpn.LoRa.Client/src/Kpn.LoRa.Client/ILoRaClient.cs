using System;
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
using AppServerRoutingProfileUpdateModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileUpdateModel;
using AppServerRoutingProfileAddModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileAddModel;
using AppServerRoutingProfileViewModel = Kpn.LoRa.Client.Models.AppServerRoutingProfileViewModel;


using Alarms = Kpn.LoRa.Client.Models.Alarms;

namespace Kpn.LoRa.Client
{
    public interface ILoRaClient : IDisposable
    {
        Task<DeviceProfiles.DeviceProfiles> GetDeviceProfiles(string subscriptionHref);
        Task<Customers.Customers> GetCustomers();
        Task<NetworkSubscriptions.NetworkSubscriptions> GetNetworkSubscriptions(string subscriptionHref);
        Task<AppServerRoutingProfiles.AppServersRoutingProfiles> GetAppServerRoutingProfiles(string subscriptionHref);
        Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> GetAppServerRoutingProfile(string appServersRoutingProfileHref);
        Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> AddAppServerRoutingProfile(string subscriptionHref, AppServerRoutingProfileAddModel.AppServersRoutingProfile appServersRoutingProfile);
        Task<AppServerRoutingProfileViewModel.AppServersRoutingProfile> UpdateAppServerRoutingProfile(string appServersRoutingProfileHref, AppServerRoutingProfileUpdateModel.AppServersRoutingProfile appServersRoutingProfile);
        Task RemoveAppServerRoutingProfile(string appServersRoutingProfileHref);
        Task<Devices.Devices> GetDevices(string subscriptionHref);
        Task<DeviceViewModel.Device> GetDevice(string deviceHref);
        Task<DeviceViewModel.Device> AddDevice(string subscriptionHref, DeviceAddModel.Device device);
        Task<DeviceViewModel.Device> UpdateDevice(string deviceHref, DeviceUpdateModel.Device device);

        Task RemoveDevice(string deviceHref);
        Task<Alarms.Alarms> GetAlarms(string deviceHref);
        Task AckAlarmsForDevice(string deviceHref);

    }
}
