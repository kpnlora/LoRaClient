using Kpn.LoRa.Api.Stub.Models;
using AppServersRoutingProfiles = Kpn.LoRa.Api.Stub.Models.AppServersRoutingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;

namespace Kpn.LoRa.Api.Stub.Controllers
{
    public class AppServersRoutingProfilesController : Controller
    {
        private static List<AppServersRoutingProfiles.Brief> _routingProfiles =
           new List<AppServersRoutingProfiles.Brief>
            {
                new AppServersRoutingProfiles.Brief
                {
                    name = "NoAS",
                    href = $"thingpark/wireless/rest/subscriptions/100/appServersRoutingProfiles/1"
                },
                new AppServersRoutingProfiles.Brief
                {
                    name = "NoAS",
                    href = $"thingpark/wireless/rest/subscriptions/100/appServersRoutingProfiles/2"
                }
            };

        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles")]
        public AppServersRoutingProfiles.AppServersRoutingProfiles Get(int subscriptionId)
        {
            return new AppServersRoutingProfiles.AppServersRoutingProfiles
            {
                briefs = _routingProfiles.ToArray()
            };
        }

        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{appServersRoutingProfileId}")]
        public AppServersRoutingProfiles.AppServersRoutingProfile Get(int subscriptionId, int appServersRoutingProfileId)
        {
            return new AppServersRoutingProfiles.AppServersRoutingProfile
            {
                name = "NoAS"
            };
        }

        [HttpPost]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles")]
        public AppServersRoutingProfiles.AppServersRoutingProfile Post(int subscriptionId, [FromBody] AppServersRoutingProfiles.AppServersRoutingProfile appServersRoutingProfile)
        {
            var newProfile = new AppServersRoutingProfiles.Brief
            {
                name = appServersRoutingProfile.name,
                href = $"thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{_routingProfiles.Count() + 1}"
            };
            _routingProfiles.Add(newProfile);
            Response.Headers.Add("Location", newProfile.href);

            return appServersRoutingProfile;
        }

        [HttpPut]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{appServersRoutingProfileId}")]
        public AppServersRoutingProfiles.AppServersRoutingProfile Put(int subscriptionId, int appServersRoutingProfileId, [FromBody] AppServersRoutingProfiles.AppServersRoutingProfile appServersRoutingProfile)
        {
            var profile = _routingProfiles
             .Single(r =>
             r.href == $"thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{appServersRoutingProfileId}");
            profile.name = appServersRoutingProfile.name;
            return appServersRoutingProfile;
        }

        [HttpDelete]
        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{appServersRoutingProfileId}")]
        public void Delete(int subscriptionId, int appServersRoutingProfileId)
        {
            _routingProfiles = _routingProfiles
                .Where(r =>
                r.href != $"thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/{appServersRoutingProfileId}")
            .ToList();
        }

        [Route("thingpark/wireless/rest/subscriptions/{subscriptionId}/appServersRoutingProfiles/tpkClouds")]
        public string GetTpkClouds(int subscriptionId)
        {
            throw new NotImplementedException("Not in API Docs");
        }
    }
}
