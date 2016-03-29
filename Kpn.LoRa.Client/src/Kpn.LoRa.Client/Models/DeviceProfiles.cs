using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.Models.DeviceProfiles
{

    public class DeviceProfiles
    {
        public Brief[] briefs { get; set; }
        public bool more { get; set; }
    }

    public class Brief
    {
        public string commercialName { get; set; }
        public string ID { get; set; }
        public string typeMAC { get; set; }
    }

}
