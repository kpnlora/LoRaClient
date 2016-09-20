namespace Kpn.LoRa.Client.Core.Models.Alarms
{
	public class Alarms
	{
		public bool more { get; set; }

		public Brief[] briefs { get; set; }
	}

	public class Brief
	{
		public long creationTimestamp { get; set; }

		public long updateTimestamp { get; set; }

		public int ID { get; set; }

		public int state { get; set; }

		public int occurrence { get; set; }

		public string addInfo { get; set; }

		public string addInfo2 { get; set; }

		public string addInfo3 { get; set; }

		public string addInfo4 { get; set; }

		public bool acked { get; set; }

		public string href { get; set; }
	}
}