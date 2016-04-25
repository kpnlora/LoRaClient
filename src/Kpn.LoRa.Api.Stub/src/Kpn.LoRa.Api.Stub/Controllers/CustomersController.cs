using Customers = Kpn.LoRa.Api.Stub.Models.Customers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Mvc;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Http;

namespace Kpn.LoRa.Api.Stub.Controllers
{
    public class CustomersController : Controller
    {
        private static Dictionary<string, string> _sessions = new Dictionary<string, string>();
        const string _jSessionCookieName = "JSESSIONID";

        [Route("thingpark/wireless/rest/customers")]
        public ActionResult Get(string adminAccessCode, string type)
        {
            //check accesscode from session
            var accessCode = _sessions[GetJSessionId()];

            if (string.IsNullOrEmpty(adminAccessCode) || adminAccessCode != accessCode)
            {

                return HttpNotFound();
            }

            return Ok(new Customers.Customers
            {
                subscription = new Customers.Subscription
                {
                    href = "/subscriptions/100"
                },
                user = new Customers.User
                {
                }
            });
        }

        [Route("thingpark/wireless/rest/customers/logout")]
        public void Logout()
        {
            _sessions.Remove(GetJSessionId());
        }


        [Route("thingpark/smp/rest/admins/id")]
        public dynamic GetThingparkId()
        {
            var session = CreateNewSession();
            var resp = new HttpResponseMessage();

            Response.Cookies.Append(_jSessionCookieName, session);

            return new { thingparkID = "tpk-001" };

            //resp.Headers.Add()
            //var cookie = new CookieHeaderValue(_jSessionCookieName, session);

            //cookie.Expires = DateTimeOffset.Now.AddDays(1);
            //cookie.Domain = Request.RequestUri.Host;
            //cookie.Path = "/";

            //resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            // var result = new { thingparkID = "tpk-001" };
            //      resp.Content = new StringContent(JsonConvert.SerializeObject(result));
            //return resp;
        }

        [HttpPost]
        [Route("thingpark/smp/rest/admins/{thingparkId}/accessCode")]
        public ActionResult GetAccessCode(string thingparkId)
        {
            //get accesscode from session 
            var accessCode = _sessions[GetJSessionId()];
            var result = new { accessCode = accessCode };

            return Ok(result);
        }

        private string CreateNewSession()
        {
            var newSession = Guid.NewGuid().ToString();
            var newAccessCode = Guid.NewGuid().ToString();

            _sessions.Add(newSession, newAccessCode);
            return newSession;
        }

        private string GetJSessionId()
        {
            string sessionId = "";
            var cookie = Request.Cookies.Single(c => c.Key == _jSessionCookieName);

            sessionId = cookie.Value.FirstOrDefault();

            return sessionId;

            //string sessionId = "";

            //CookieHeaderValue cookie = Request.Headers.GetCookies(_jSessionCookieName).FirstOrDefault();
            //if (cookie != null)
            //{
            //    sessionId = cookie[_jSessionCookieName].Value;

            //}

            //return sessionId;
        }
    }
}
