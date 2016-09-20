using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Kpn.LoRa.Api.Stub.Payload;
using System.Net.Http;
using System.Text.RegularExpressions;
using Kpn.LoRa.Api.Stub.Models.AppServersRoutingProfiles;
using Kpn.LoRa.Api.Stub.Models.Device;
using System.Text;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kpn.LoRa.Api.Stub.Controllers
{

    public class PayloadController : Controller
    {
        
        [HttpPost]
        [Route("api/Payload/PostToAllEndpoints")]
        public async Task Post([FromBody]string payload)
        {
            await PostMessageFromAllDevicesToAllEndpoints(payload);
        }

        [HttpPost]
        [Route("api/Payload/PostToEndpoint")]
        public async Task Post(string endpoint, [FromBody]string payload)
        {
            var device = new Device
            {
                EUI = "00000000ABBA0005"
            };
            var uplinkMessage = CreateUplinkMessage(device, payload);

            string messageBody = SerializeUplinkMessage(uplinkMessage);
            await PostMessageAsync(endpoint, messageBody);
        }

        private async Task PostMessageFromAllDevicesToAllEndpoints(string payload)
        {
            foreach (var deviceBrief in new DevicesController().Get(100).briefs)
            {

                var device = new DevicesController().Get(100, Convert.ToInt32(deviceBrief.href.Split('/').Last()));
                var routingProfile = new AppServersRoutingProfilesController().Get(100, Convert.ToInt32(device.appServersRoutingProfile.href.Split('/').Last()));


                var uplinkMessage = CreateUplinkMessage(device, payload);

                string messageBody = SerializeUplinkMessage(uplinkMessage);

                foreach (var route in routingProfile.routes)
                {
                    foreach (var dest in route.GetDestinations().dest.Where(d => d.type == "HTTP"))
                    {
                        await PostMessageAsync(dest.address, messageBody);
                    }
                }
            }

        }

        private DevEUI_uplink CreateUplinkMessage(Device device, string payload)
        {
            return new DevEUI_uplink
            {
                DevEUI = device.EUI,
                Time = DateTime.UtcNow,
                payload_hex = EncodePayloadToHex(payload),
                CustomerData = "{\"alr\":{\"pro\":\"MC/IOT\",\"ver\":\"1\"}}"
            };
        }

        private string EncodePayloadToHex(string payload)
        {
            var result = new StringBuilder();
            var characters = payload.ToCharArray();

            foreach (var character in characters)
            {
                result.AppendFormat("{0:X}", Convert.ToInt32(character));
            }

            return result.ToString();
        }

        private async Task PostMessageAsync(string uri, string messageBody)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.PostAsync(uri, new StringContent(messageBody));
            }
        }

        private string SerializeUplinkMessage(DevEUI_uplink message)
        {
            string result;
            var serializer = new XmlSerializer(message.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, message);
                result = stream.ToString();
            }
            return result;
        }

    }



    public static class RouteExtensions
    {


        public static Destinations GetDestinations(this Route route)
        {
            return Destinations.FromXmlString(route.destinations);
        }

    }

    public class Destinations
    {
        public List<Destination> dest { get; set; }



        public static Destinations FromXmlString(string xml)
        {
            var dests = new List<Destination>();
            //xml serializing dependency problems in .netcore, cleanup!
            try
            {
                foreach (Match destMatch in Regex.Matches(xml, "<dest (.*?)/>"))
                {
                    dests.Add(new Destination
                    {
                        type = Regex.Match(destMatch.Value, "type=\"(.*?)\"").Groups[1].Value,
                        address = Regex.Match(destMatch.Value, "address=\"(.*?)\"").Groups[1].Value
                    });
                }
            }
            catch { }

            return new Destinations { dest = dests };
        }
    }

    public class Destination
    {

        public string type { get; set; }

        public string address { get; set; }


    }


}