using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Kpn.LoRa.Client.Core.Models.AppServerRoutingProfileUpdateModel;

namespace Kpn.LoRa.Client.Core.Extensions
{
	public static class RouteExtensions
	{
		public static void SetDestinations(this Route route, Destinations destinations)
		{
			route.destinations = destinations.ToXmlString();
		}

		public static Destinations SetDestinations(this Route route)
		{
			return Destinations.FromXmlString(route.destinations);
		}

	}

	public class Destinations
	{
		public List<Destination> dest { get; set; }

		public string ToXmlString()
		{
			//xml serializing dependency problems in .netcore, cleanup!
			return $"<dests>{dest.Select(d => d.ToXmlString())}</dests>";
		}

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

		public string ToXmlString()
		{
			return $"<dest type=\"{type}\" address=\"{address}\" />";
		}
	}


}
