using Betabit.Lora.Nuget.Example.Models;
using Betabit.Lora.Nuget.Example.ViewModels;
using Kpn.LoRa.Client;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Betabit.Lora.Nuget.Example.Controllers
{
	/// <summary>
	/// This controller is used to manage Rooms.
	/// It consists of basic CRUD operations and calls to
	/// register/unregister a device on the LoRa network.
	/// </summary>
	/// <seealso cref="Betabit.Lora.Nuget.Example.Controllers.BaseController" />
	public class DevicesController : BaseController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DevicesController"/> class.
		/// </summary>
		/// <param name="configuration">The application configuration.</param>
		/// <param name="appDbContext">The application database context.</param>
		public DevicesController(IConfigurationRoot configuration, AppDbContext appDbContext) 
			: base(configuration, appDbContext)
		{
		}

		[HttpGet]
		public IActionResult Index()
		{
			// Retrieve all the devices from the context
			var devices = _context.Devices.Include(d => d.Room).ToList();

			// Render the overview with the devices
			return View(devices);
		}

		[HttpGet]
		public IActionResult Details(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Render the details view with the device
			return View(device);
		}

		[HttpGet]
		public IActionResult Create()
		{
			// Create the device viewmodel
			var vm = new DeviceViewModel()
			{
				AvailableRooms = _context.Rooms.ToList()
			};

			// Render the creation view using the viewmodel
			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(DeviceViewModel deviceViewModel)
		{
			// Make sure the model is valid
			if (ModelState.IsValid)
			{
				// Create the device
				var device = new Device()
				{
					Name = deviceViewModel.Name,
					Room = _context.Rooms.Single(m => m.Id == deviceViewModel.RoomId),
					DeviceAddress = deviceViewModel.DeviceAddress,
					NetworkAddress = deviceViewModel.NetworkAddress,
					NetworkKey = deviceViewModel.NetworkKey
				};

				// Add the device
				_context.Devices.Add(device);
				_context.SaveChanges();

				// Redirect the user back to the index page
				return RedirectToAction("Index");
			}

			// If the viewmodel is not valid, show the view again with the errors
			return View(deviceViewModel);
		}

		public IActionResult Edit(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Create the device viewmodel
			var vm = new DeviceViewModel()
			{
				Id = device.Id,
				Name = device.Name,
				RoomId = device.Room.Id,
				AvailableRooms = _context.Rooms.ToList(),
				DeviceAddress = device.DeviceAddress,
				NetworkAddress = device.NetworkAddress,
				NetworkKey = device.NetworkKey
			};

			// Render the edit view using the viewmodel
			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(DeviceViewModel deviceViewModel)
		{
			// Make sure the model is valid
			if (ModelState.IsValid)
			{
				// Update the device
				var device = new Device()
				{
					Id = deviceViewModel.Id,
					Name = deviceViewModel.Name,
					Room = _context.Rooms.Single(m => m.Id == deviceViewModel.RoomId),
					DeviceAddress = deviceViewModel.DeviceAddress,
					NetworkAddress = deviceViewModel.NetworkAddress,
					NetworkKey = deviceViewModel.NetworkKey
				};

				// Update the device
				_context.Devices.Update(device);
				_context.SaveChanges();

				// Redirect the user back to the index page
				return RedirectToAction("Index");
			}

			// If the viewmodel is not valid, show the view again with the errors
			return View(deviceViewModel);
		}

		[ActionName("Delete")]
		public IActionResult Delete(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Render the details view with the device
			return View(device);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// Find the device using the unique identifier
			var device = _context.Devices.Single(m => m.Id == id);

			// Remove the device
			_context.Devices.Remove(device);
			_context.SaveChanges();

			// Redirect the user back to the index page
			return RedirectToAction("Index");
		}


		[HttpGet]
		public async Task<IActionResult> Register(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();
				var deviceProfiles = await client.GetDeviceProfiles(customers.subscription.href);

				var modelId = deviceProfiles.briefs.First().ID;
				var loraDevice = new Kpn.LoRa.Client.Models.DeviceAddModel.Device
				{
					name = device.Name,
					model = new Kpn.LoRa.Client.Models.DeviceAddModel.Model
					{
						ID = modelId
					},
					nwAddress = device.NetworkAddress,
					EUI = device.DeviceAddress,
					nwKey = device.NetworkKey
				};

				var result = await client.AddDevice(customers.subscription.href, loraDevice);
			}

			// Render the details view with the device
			return View("Details", device);
		}

		[HttpGet]
		public async Task<IActionResult> Unregister(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();
				var devices = await client.GetDevices(customers.subscription.href);

				var loraDevice = devices.briefs.FirstOrDefault(d => d.name == device.Name);

				if (loraDevice != null)
				{
					await client.RemoveDevice(loraDevice.href);
				}
			}

			// Render the details view with the device
			return View("Details", device);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateRegistration(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct device using the ID
			var device = _context.Devices.Include(d => d.Room).Single(m => m.Id == id.Value);

			if (device == null)
			{
				// If no device could be found, show a 404 page
				return HttpNotFound();
			}

			// Make a connection with the LoRa network
			using (ILoRaClient client = CreateLoRaClient())
			{
				var customers = await client.GetCustomers();
				var deviceProfiles = await client.GetDeviceProfiles(customers.subscription.href);

				var modelId = deviceProfiles.briefs.First().ID;

				var loraDevices = await client.GetDevices(customers.subscription.href);
				var oldDevice = loraDevices.briefs.Single(d => d.EUI == device.DeviceAddress);

				var updatedDevice = new Kpn.LoRa.Client.Models.DeviceUpdateModel.Device
				{
					name = device.Name,
					nwKey = device.NetworkKey
				};

				var result = await client.UpdateDevice(oldDevice.href, updatedDevice);
			}

			// Render the details view with the device
			return View("Details", device);
		}
	}
}
