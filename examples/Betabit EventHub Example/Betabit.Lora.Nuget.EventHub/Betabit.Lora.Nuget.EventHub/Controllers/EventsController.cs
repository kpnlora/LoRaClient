using Kpn.LoRa.Reader;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Linq;

namespace Betabit.Lora.Nuget.EventHub.Controllers
{
	public class EventsController : ApiController
	{
		/// <summary>
		/// This encapsulation provides the connection info for the service bus event hub.
		/// This info is retrieved from the AppSettings section in the Web.Config
		/// Make sure the key "Microsoft.ServiceBus.ConnectionString" is correctly provided.
		/// </summary>
		public static string ConnectionInfo
		{
			get
			{
				// Retrieve the connection string from the Web.Config
				var connectionInfo = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

				// Make sure we have a connection string
				if (string.IsNullOrWhiteSpace(connectionInfo))
				{
					throw new ArgumentException("You need to provide the service bus connection string in the Web.Config");
				}

				// Return the connection string
				return connectionInfo;
			}
		}

		// GET: /Api/Events/PostClimateReading
		[HttpPost]
		public StatusCodeResult PostClimateReading(HttpRequestMessage request)
		{
			try
			{
				// Parse data into valid XML
				var xdoc = XDocument.Load(request.Content.ReadAsStreamAsync().Result);

				// Retrieve the information from the XML using a LoRaReader
				var reader = new LoRaReader(xdoc);
				var time = reader.GetTime();
				var data = reader.GetPayload();

				// Send the data to the event hub
				var client = EventHubClient.CreateFromConnectionString(ConnectionInfo);
				client.Send(new EventData(Encoding.UTF8.GetBytes(data)));
				client.Close();
			}
			catch (Exception ex)
			{
				// TODO : Logging
				Console.WriteLine(ex.InnerException);

				return new StatusCodeResult(HttpStatusCode.InternalServerError, this);
			}

			return new StatusCodeResult(HttpStatusCode.OK, this);
		}
	}
}