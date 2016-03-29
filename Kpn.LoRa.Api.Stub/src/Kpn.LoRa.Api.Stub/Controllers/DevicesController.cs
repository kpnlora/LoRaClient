using Kpn.LoRa.Api.Stub.Models;
using Devices = Kpn.LoRa.Api.Stub.Models.Devices;
using Device = Kpn.LoRa.Api.Stub.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Kpn.LoRa.Api.Stub.Controllers
{

    public class DevicesController : Controller
    {
        private static int _deviceSequenceId = 6000;

        private static List<Devices.Brief> _devices = new List<Devices.Brief>
        {
             new Devices.Brief
                    {
                        name = "Dev1",
                        model = new Devices.Model
                        {
                            commercialName = "LoRaWAN 1.0 class A"
                        },
                        href =$"/thingpark/wireless/rest/subscriptions/100/devices/5000"

                    },
                    new Devices.Brief
                    {
                        name = "Dev2",
                        model = new Devices.Model
                        {
                            commercialName = "LoRaWAN 1.0 class C"
                        },
                        href =$"/thingpark/wireless/rest/subscriptions/100/devices/5001"
                    }
        };


        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices")]
        public Devices.Devices Get(int subscriptionId)
        {
            return new Devices.Devices
            {
                briefs = _devices.ToArray()
            };

        }

        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}")]
        public Device.Device Get(int subscriptionId, int deviceId)
        {
            var brief = Get(subscriptionId).briefs
                .FirstOrDefault(b => b.href == $"/thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}");

            return new Device.Device
            {
                name = brief.name,
                model = new Device.Model
                {
                    commercialName = brief.model.commercialName
                }
            };
        }

        [HttpPost]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices")]
        public Device.Device Post(int subscriptionId, [FromBody] Device.Device device)
        {
            _deviceSequenceId++;
            var briefs = _devices.ToList();
            var newBrief = new Models.Devices.Brief
            {
                name = device.name,
                EUI = device.EUI,
                href = $"/thingpark/wireless/rest/subscriptions/100/devices/{_deviceSequenceId}"
            };

        
            _devices.Add(newBrief);

            
            Response.Headers.Add("Location", newBrief.href);

            return device;
        }

        [HttpPut]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}")]
        public Device.Device Put(int subscriptionId, int deviceId, [FromBody] Device.Device device)
        {
            var targetDevice = _devices
                .Single(b => b.href == $"/thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}");

            targetDevice.name = device.name;

            return device;
        }

        [HttpDelete]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}")]
        public void Delete(int subscriptionId, int deviceId)
        {
            _devices.RemoveAll(d =>
            d.href == $"/thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}");
        }

        /*
                      [HttpPost]
                      [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/import")]
                      public void Import(int subscriptionId, System.Web.HttpPostedFile csvUpload)
                      {
                          if (!csvUpload.FileName.ToLower().EndsWith(".csv"))
                          {
                              BadRequest("Unsupported filetype");
                          }

                          throw new NotImplementedException();
                      }


                      [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/frames")]
                      public string GetFrames(int subscriptionId, int deviceId)
                      {
                          throw new NotImplementedException();
                      }

                      [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/locations")]
                      public string GetLocations(int subscriptionId, int deviceId)
                      {
                          throw new NotImplementedException();
                      }

                      [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/devices/{deviceId}/batLevels")]
                      public string GetBatLevels(int subscriptionId, int deviceId)
                      {
                          throw new NotImplementedException();
                      }

                  */
    }
}
