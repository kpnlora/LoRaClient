using System.ComponentModel.DataAnnotations;

namespace Betabit.Lora.Nuget.Example.Models
{
	/// <summary>
	/// This class represents a Device.
	/// A device is connected to a specific Room .
	/// </summary>
	public class Device
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
		/// Gets or sets the room to which the device is connected.
		/// </summary>
		public virtual Room Room { get; set; }

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