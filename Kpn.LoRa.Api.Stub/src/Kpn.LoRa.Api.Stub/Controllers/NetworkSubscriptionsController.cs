using Kpn.LoRa.Api.Stub.Models;
using NetworkSubscriptions=Kpn.LoRa.Api.Stub.Models.NetworkSubscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;

namespace Kpn.LoRa.Api.Stub.Controllers
{
    public class NetworkSubscriptionsController : Controller
    {
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/networkSubscriptions")]
        public NetworkSubscriptions.NetworkSubscriptions Get(int subscriptionId)
        {
            return new NetworkSubscriptions.NetworkSubscriptions
            {
                briefs = new NetworkSubscriptions.Brief[]
                {
                    new NetworkSubscriptions.Brief { commercialName="Production" },
                    new NetworkSubscriptions.Brief { commercialName="Demo" }
                }
            };
        }

        [HttpPost]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/networkSubscriptions")]
        public void Post(int subscriptionId, [FromBody] string networkSubscription)
        {
            throw new NotImplementedException("No API example");
        }

        [HttpGet]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/networkSubscriptions/{networkSubscriptionId}")]
        public void Get(int subscriptionId, int networkSubscriptionId)
        {
            throw new NotImplementedException("No API example");
        }

        [HttpPut]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/networkSubscriptions/{networkSubscriptionId}")]
        public void Post(int subscriptionId, int networkSubscriptionId, [FromBody] string networkSubscription)
        {
            throw new NotImplementedException("No API example");
        }

        [HttpDelete]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/networkSubscriptions/{networkSubscriptionId}")]
        public void Delete(int subscriptionId, int networkSubscriptionId)
        {
            throw new NotImplementedException("No API example");
        }


        [HttpGet]
        [Route("thingpark/wireless/rest/subscriptions/networkSubscriptions/{networkSubscriptionId}/transactions")]
        public IEnumerable<string> GetTransactions(int subscriptionId, int networkSubscriptionId)
        {
            throw new NotImplementedException("No API example");
        }
    }
}
