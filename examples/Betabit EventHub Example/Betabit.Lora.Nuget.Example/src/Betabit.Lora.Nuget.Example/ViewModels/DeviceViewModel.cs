using Betabit.Lora.Nuget.Example.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Betabit.Lora.Nuget.Example.ViewModels
{
	/// <summary>
	/// This viewmodel is used for creating and editing devices.
	/// It has information about the device, the associated room and available rooms.
	/// </summary>
	public class DeviceViewModel
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the room identifier.
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		/// Gets or sets the available rooms.
		/// Used in the views to populate the select list.
		/// </summary>
		public List<Room> AvailableRooms { get; set; }

		/// <summary>
		/// Gets or sets the device address used for the LoRa network.
		/// </summary>
		[Display(Name = "EUI")]
		public string DeviceAddress { get; set; }

		/// <summary>
		/// Gets or sets the network address used for the LoRa network.
		/// </summary>
		[Display(Name = "Network address")]
		public string NetworkAddress { get; set; }

		/// <summary>
		/// Gets or sets the network key used for the LoRa network.
		/// </summary>
		[Display(Name = "Network key")]
		public string NetworkKey { get; set; }
	}
}
