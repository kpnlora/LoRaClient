namespace Kpn.LoRa.Client.Core.Models.DeviceProfiles
{
	public class DeviceProfiles
	{
		public Brief[] briefs { get; set; }

		public bool more { get; set; }
	}

	public class Brief
	{
		public string commercialName { get; set; }

		public string ID { get; set; }

		public string typeMAC { get; set; }
	}
}
