using System.Linq;
using Kpn.LoRa.Client.Core.Extensions;
using Xunit;
using AppServerRoutingProfileAddModel = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileAddModel;
using AppServerRoutingProfileUpdateModel = Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileUpdateModel;
using DeviceAddModel = Kpn.LoRa.Client.Core.Models.DeviceAddModel;
using DeviceUpdateModel = Kpn.LoRa.Client.Core.Models.DeviceUpdateModel;

namespace Kpn.LoRa.Client.Core.Tests
{
	public class ClientToStubTests
	{
		private string _username;
		private string _password;
		private string _subscriberId;
		private string _endPoint;

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientToStubTests"/> class.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="subscriberId">The subscriber identifier.</param>
		/// <param name="endpoint">The endpoint.</param>
		internal ClientToStubTests(string username, string password, string subscriberId, string endpoint)
		{
			_username = username;
			_password = password;
			_subscriberId = subscriberId;
			_endPoint = endpoint;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientToStubTests"/> class.
		/// This constructor uses the default settings for the stub.
		/// </summary>
		public ClientToStubTests() : this("nobody", "notasecret", "100000000", "https://localhost:44394/")
		{
			//default
		}

		ILoRaClient CreateLoRaClient()
		{

			return new LoRaClient(_username, _password, _subscriberId, _endPoint);
		}

		[Fact]
		public void GetCustomersTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				Assert.NotNull(customers);
				Assert.NotNull(customers.subscription.href);
			}
		}

		[Fact]
		public void GetDeviceProfilesTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;

				var deviceProfiles = client.GetDeviceProfiles(customers.subscription.href).Result;

				Assert.Equal("LoRaWAN 1.0 class A", deviceProfiles.briefs.First().commercialName);
			}
		}

		[Fact]
		public void GetNetworkSubscriptionsTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;

				var networkSubscriptions = client.GetNetworkSubscriptions(customers.subscription.href).Result;

				Assert.Equal("Production", networkSubscriptions.briefs.First().commercialName);
			}
		}

		[Fact]
		public void GetAppServerRoutingProfilesTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var routingProfiles = client.GetAppServerRoutingProfiles(customers.subscription.href).Result;
				var routingProfile = client.GetAppServerRoutingProfile(routingProfiles.briefs.First().href).Result;

				Assert.Equal("NoAS", routingProfiles.briefs.First().name);
				Assert.Equal("NoAS", routingProfile.name);
			}
		}

		[Fact]
		public void GetDevicesTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var devices = client.GetDevices(customers.subscription.href).Result;

				Assert.Equal("LoRaWAN 1.0 class A", devices.briefs.First().model.commercialName);
			}
		}

		[Fact]
		public void GetDeviceTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var devices = client.GetDevices(customers.subscription.href).Result;
				var device = client.GetDevice(devices.briefs.First().href).Result;

				Assert.Equal("LoRaWAN 1.0 class A", device.model.commercialName);
			}
		}

		[Fact]
		public void GetAlarmsTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var devices = client.GetDevices(customers.subscription.href).Result;
				var alarms = client.GetAlarms(devices.briefs.First().href).Result;
			}
		}

		[Fact]
		public void AckAllAlarmsTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var devices = client.GetDevices(customers.subscription.href).Result;
				client.AckAlarmsForDevice(devices.briefs.First().href);
			}
		}


		[Fact]
		public void AddAppServerRoutingProfilesTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;

				var appServersRoutingProfile = new AppServerRoutingProfileAddModel.AppServersRoutingProfile
				{
					name = "AddAppServerRoutingProfiles_ut"
				};

				var result = client.AddAppServerRoutingProfile(customers.subscription.href, appServersRoutingProfile).Result;
				var routingProfiles = client.GetAppServerRoutingProfiles(customers.subscription.href).Result;

				//cleanup
				client.RemoveAppServerRoutingProfile(result.href);

				Assert.True(routingProfiles.briefs.Any(p => p.name == "AddAppServerRoutingProfiles_ut"));
			}

		}

		[Fact]
		public void UpdateAppServerRoutingProfilesTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;

				var appServersRoutingProfile = new AppServerRoutingProfileAddModel.AppServersRoutingProfile
				{
					name = "UpdateAppServerRoutingProfiles_ut"
				};

				var result = client.AddAppServerRoutingProfile(customers.subscription.href, appServersRoutingProfile).Result;
				var routingProfile = client.GetAppServerRoutingProfile(result.href).Result;

				var updateProfile = new AppServerRoutingProfileUpdateModel.AppServersRoutingProfile
				{
					name = "UpdatedAppServerRoutingProfiles_ut",
					routes = new AppServerRoutingProfileUpdateModel.Route[]
					{
					   CreateSimpleRoute("https://endpoint.localhost:44301")
					}
				};

				var updatedProfile = client.UpdateAppServerRoutingProfile(result.href, updateProfile).Result;

				Assert.True(client.GetAppServerRoutingProfiles(customers.subscription.href)
					.Result.briefs.Any(p => p.name == "UpdatedAppServerRoutingProfiles_ut"));

				//cleanup
				client.RemoveAppServerRoutingProfile(result.href);
			}
		}

		private static AppServerRoutingProfileUpdateModel.Route CreateSimpleRoute(string destAddress)
		{
			var route = new AppServerRoutingProfileUpdateModel.Route
			{
				sourcePort = "*",
				strategy = "SEQUENTIAL"
			};


			route.SetDestinations(new Destinations
			{

				dest = new System.Collections.Generic.List<Destination>
			   {
				   new Destination {type="HTTP", address=destAddress },

			   }
			});
			return route;
		}

		[Fact]
		public void AddDeviceTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var deviceProfiles = client.GetDeviceProfiles(customers.subscription.href).Result;
				var modelId = deviceProfiles.briefs.First().ID;
				var device = new DeviceAddModel.Device
				{
					name = "AddDeviceTest_ut",
					model = new DeviceAddModel.Model
					{
						ID = modelId
					},
					nwAddress = "0B60D265",
					EUI = "200000000F252D98",
					nwKey = "12345678901234567890123456789012"
				};


				var result = client.AddDevice(customers.subscription.href, device).Result;

				var allCurrentDevices = client.GetDevices(customers.subscription.href).Result;
				//cleanup
				client.RemoveDevice(result.href);

				Assert.NotNull(result);
				Assert.True(allCurrentDevices.briefs.Any(d => d.EUI == "200000000F252D98"));

			}
		}

		[Fact]
		public void RemoveDeviceTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var deviceProfiles = client.GetDeviceProfiles(customers.subscription.href).Result;
				var modelId = deviceProfiles.briefs.First().ID;
				var newDevice = new DeviceAddModel.Device
				{
					name = "RemoveDeviceTest_ut",
					model = new DeviceAddModel.Model
					{
						ID = modelId
					},
					nwAddress = "0B60D266",
					EUI = "200000000F252D95",
					nwKey = "12345678901234567890123456789013"
				};

				var result = client.AddDevice(customers.subscription.href, newDevice).Result;
				var devices = client.GetDevices(customers.subscription.href).Result;

				//act
				client.RemoveDevice(result.href);


				Assert.True(devices.briefs
					.Any(d => d.EUI == "200000000F252D95"));

				var endresult = client.GetDevices(customers.subscription.href).Result.briefs;

				Assert.False(endresult
					.Any(d => d.EUI == "200000000F252D95"));
			}
		}

		[Fact]
		public void UpdateDeviceTest()
		{
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = client.GetCustomers().Result;
				var deviceProfiles = client.GetDeviceProfiles(customers.subscription.href).Result;
				var modelId = deviceProfiles.briefs.First().ID;
				var newDevice = new DeviceAddModel.Device
				{
					name = "UpdateDeviceTest_ut",
					model = new DeviceAddModel.Model
					{
						ID = modelId
					},
					nwAddress = "0B60D267",
					EUI = "200000000F252D97",
					nwKey = "12345678901234567890123456789015"
				};

				var result = client.AddDevice(customers.subscription.href, newDevice).Result;
				var devices = client.GetDevices(customers.subscription.href).Result;
				var device = devices.briefs.First(d => d.EUI == "200000000F252D97");

				//Act
				var updateDevice = new DeviceUpdateModel.Device
				{
					name = "UpdatedDeviceTest_ut",
					nwKey = "12345678901234567890123456789015"
				};
				newDevice.name = "UpdatedDeviceTest_ut";
				var updateResult = client.UpdateDevice(device.href, updateDevice).Result;

				//Get Aftermath
				var afterupdatedevices = client.GetDevices(customers.subscription.href).Result;
				var afterupdatedevice = afterupdatedevices.briefs.First(d => d.EUI == "200000000F252D97");

				//Cleanup
				client.RemoveDevice(device.href);

				//Assert
				Assert.Equal("UpdatedDeviceTest_ut", afterupdatedevice.name);
			}
		}
	}
}