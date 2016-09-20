using Microsoft.AspNetCore.Mvc;
using Alarms = Kpn.LoRa.Api.Stub.Models.Alarms;

namespace Kpn.LoRa.Api.Stub.Controllers
{
	public class AlarmController : Controller
	{
		[Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/alarms")]
		public Alarms.Alarms Get(int subscriptionId, int deviceId)
		{
			return new Alarms.Alarms
			{
				briefs = new Alarms.Brief[]
				{
					new Alarms.Brief
					{
						acked = false,
						href = $"/thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/alarms/1a1a"
					},
					new Alarms.Brief
					{
						acked = false,
						href = $"/thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/alarms/2b2b"
					}
				}
			};
		}

		[HttpPost]
		[Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/alarms/ack")]
		public void AckAlarms(int subscriptionId, int deviceId)
		{

		}

		[HttpPost]
		[Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/alarms/{alarmId}/ack")]
		public void AckAlarm(int subscriptionId, int deviceId, int alarmId)
		{

		}
	}
}