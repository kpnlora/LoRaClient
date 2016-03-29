using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.Models.NetworkSubscriptions
{

    public class NetworkSubscriptions
    {
        public Brief[] briefs { get; set; }
    }

    public class Brief
    {
        public string commercialName { get; set; }
        public string ID { get; set; }
        public int used { get; set; }
        public int granted { get; set; }
        public string href { get; set; }
    }

}
