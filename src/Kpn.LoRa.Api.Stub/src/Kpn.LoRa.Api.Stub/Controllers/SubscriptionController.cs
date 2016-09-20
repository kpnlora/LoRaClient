using Kpn.LoRa.Api.Stub.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Kpn.LoRa.Api.Stub.Controllers
{
    public class SubscriptionController : Controller
    {
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}")]
        public subscription Get(int subscriptionId)
        {
            return new subscription
            {

            };
        }

        [HttpPut]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}")]
        public subscription Put(int subscriptionId, [FromBody] subscription subscription)
        {
            return subscription;
        }
    }
}
