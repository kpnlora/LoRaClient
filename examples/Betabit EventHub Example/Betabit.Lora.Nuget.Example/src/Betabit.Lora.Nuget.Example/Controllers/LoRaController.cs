using Betabit.Lora.Nuget.Example.Models;
using Betabit.Lora.Nuget.Example.ViewModels;
using Kpn.LoRa.Client;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;


namespace Betabit.Lora.Nuget.Example.Controllers
{
	/// <summary>
	/// This controller is used to view information from the LoRa network.
	/// This includes customers, device profiles and network subscriptions.
	/// </summary>
	/// <seealso cref="Betabit.Lora.Nuget.Example.Controllers.BaseController" />
	public class LoRaController : BaseController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LoRaController"/> class.
		/// </summary>
		/// <param name="configuration">The application configuration.</param>
		/// <param name="appDbContext">The application database context.</param>
		public LoRaController(IConfigurationRoot configuration, AppDbContext appDbContext)
			: base(configuration, appDbContext)
		{
		}

		[HttpGet]
		public async Task<IActionResult> Customers()
		{
			// Customer view model
			var vm = new CustomerViewModel();

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();

				vm.FastName  = customers.user.fastName;
				vm.FirstName = customers.user.firstName;
			}

			// Render the view
			return View(vm);
		}

		public async Task<IActionResult> DeviceProfiles()
		{
			// Device profiles view model
			var vm = new List<DeviceProfileViewModel>();

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();
				var deviceProfiles = await client.GetDeviceProfiles(customers.subscription.href);

				// Create a viewmodel for each profile
				foreach (var profile in deviceProfiles.briefs)
				{
					vm.Add(new DeviceProfileViewModel()
					{
						ID             = profile.ID,
						CommercialName = profile.commercialName,
						TypeMAC        = profile.typeMAC
					});
				}
			}

			// Render the view
			return View(vm);
		}

		public async Task<IActionResult> NetworkSubscriptions()
		{
			// Network subscriptions view model
			var vm = new List<NetworkSubscriptionViewModel>();

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();
				var networkSubscriptions = await client.GetNetworkSubscriptions(customers.subscription.href);

				// Create a viewmodel for each profile
				foreach (var profile in networkSubscriptions.briefs)
				{
					vm.Add(new NetworkSubscriptionViewModel()
					{
						ID = profile.ID,
						CommercialName = profile.commercialName,
						Used = profile.used.ToString(),
						Granted = profile.granted.ToString(),
					});
				}
			}

			// Render the view
			return View(vm);
		}
	}
}
