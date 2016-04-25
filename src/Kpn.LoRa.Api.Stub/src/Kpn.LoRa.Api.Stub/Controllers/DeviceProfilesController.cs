using Kpn.LoRa.Api.Stub.Models;
using DeviceProfiles=Kpn.LoRa.Api.Stub.Models.DeviceProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;

namespace Kpn.LoRa.Api.Stub.Controllers
{
    public class DeviceProfilesController : Controller
    {
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/deviceProfiles")]
        public DeviceProfiles.DeviceProfiles Get(int subscriptionId)
        {
            return new DeviceProfiles.DeviceProfiles
            {
                briefs = new DeviceProfiles.Brief[]
                {
                    new DeviceProfiles.Brief { commercialName="LoRaWAN 1.0 class A"},
                    new DeviceProfiles.Brief { commercialName="LoRaWAN 1.0 class C"},
                }
            };
        }
    }
}
