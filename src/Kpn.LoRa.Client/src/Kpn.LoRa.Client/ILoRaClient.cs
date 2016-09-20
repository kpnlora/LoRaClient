using System;
using System.Threading.Tasks;
using Alarms = Kpn.LoRa.Client.Core.Models.Alarms;
using AppServerRoutingProfileAddModel = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileAddModel;
using AppServerRoutingProfiles = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfiles;
using AppServerRoutingProfileUpdateModel = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileUpdateModel;
using AppServerRoutingProfileViewModel = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileViewModel;
using Customers = Kpn.LoRa.Client.Core.Models.Customers;
using DeviceAddModel = Kpn.LoRa.Client.Core.Models.DeviceAddModel;
using DeviceProfiles = Kpn.LoRa.Client.Core.Models.DeviceProfiles;
using Devices = Kpn.LoRa.Client.Core.Models.Devices;
using DeviceUpdateModel = Kpn.LoRa.Client.Core.Models.DeviceUpdateModel;
using DeviceViewModel = Kpn.LoRa.Client.Core.Models.DeviceViewModel;
using NetworkSubscriptions = Kpn.LoRa.Client.Core.Models.NetworkSubscriptions;

namespace Kpn.LoRa.Client.Core
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
