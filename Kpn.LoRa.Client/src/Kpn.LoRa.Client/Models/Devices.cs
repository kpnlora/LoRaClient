using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.Models.Devices
{
    public class Devices
    {
        public Brief[] briefs { get; set; }
        public bool more { get; set; }
        public long? now { get; set; }
    }

    public class Brief
    {
        public string name { get; set; }
        public Model model { get; set; }
        public string EUI { get; set; }
        public string nwAddress { get; set; }
        public Networksubscription networkSubscription { get; set; }
        public int? markerID { get; set; }
        public long? lastUpTimestamp { get; set; }
        public long? lastDwTimestamp { get; set; }
        public float? lastRSSI { get; set; }
        public float? lastSNR { get; set; }
        public float? avgRSSI { get; set; }
        public float? avgSNR { get; set; }
        public int? lastSF { get; set; }
        public object lastBatLevel { get; set; }
        public int? alarmCount { get; set; }
        public int? alarmLevel { get; set; }
        public float? lat { get; set; }
        public float? lon { get; set; }
        public object radius { get; set; }
        public string href { get; set; }
        public Historyupdaily historyUpDaily { get; set; }
        public Historydwdaily historyDwDaily { get; set; }
    }

    public class Model
    {
        public string commercialName { get; set; }
        public string logo { get; set; }
        public string c21commercialName { get; set; }
    }

    public class Networksubscription
    {
        public string commercialName { get; set; }
    }

    public class Historyupdaily
    {
        public int?[] val { get; set; }
    }

    public class Historydwdaily
    {
        public int?[] val { get; set; }
    }
}

namespace Kpn.LoRa.Client.Models.DeviceViewModel
{

    public class Device
    {
        public string href { get; set; }
        public long? now { get; set; }
        public Occcontext occContext { get; set; }
        public string name { get; set; }
        public Model model { get; set; }
        public string EUI { get; set; }
        public string nwAddress { get; set; }
        public string nwKey { get; set; }
        public string appKeys { get; set; }
        public Networksubscription networkSubscription { get; set; }
        public Appserversroutingprofile appServersRoutingProfile { get; set; }
        public object modelConfig { get; set; }
        public string customerAdminData { get; set; }
        public int? markerID { get; set; }
        public object alarm004 { get; set; }
        public long? firstUpTimestamp { get; set; }
        public long? lastUpTimestamp { get; set; }
        public long? lastDwTimestamp { get; set; }
        public float? lastRSSI { get; set; }
        public float? lastSNR { get; set; }
        public float? avgRSSI { get; set; }
        public float? avgSNR { get; set; }
        public int? lastSF { get; set; }
        public long? lastBatLevel { get; set; }
        public long? lastBatLevelTimestamp { get; set; }
        public long? lastBatChanged { get; set; }
        public long? lastBatChangeBy { get; set; }
        public Historyupdaily historyUpDaily { get; set; }
        public Historydwdaily historyDwDaily { get; set; }
        public int? alarm6 { get; set; }
        public int? alarm5 { get; set; }
        public int? alarm4 { get; set; }
        public int? alarm3 { get; set; }
        public int? alarm2 { get; set; }
        public int? alarm1 { get; set; }
        public float? lastGeoLat { get; set; }
        public float? lastGeoLon { get; set; }
        public float? lastGeoRadius { get; set; }
        public long? lastGeoTimestamp { get; set; }
        public float? adminLat { get; set; }
        public float? adminLon { get; set; }
        public int? locationType { get; set; }
        public Lrr[] LRRs { get; set; }
    }

    public class Occcontext
    {
        public int? version { get; set; }
        public long? lastUpdate { get; set; }
        public string who { get; set; }
    }

    public class Model
    {
        public string commercialName { get; set; }
        public string logo { get; set; }
        public string typeMAC { get; set; }
        public string ID { get; set; }
    }

    public class Networksubscription
    {
        public string commercialName { get; set; }
        public string ID { get; set; }
        public bool mobility { get; set; }
        public string href { get; set; }
    }

    public class Appserversroutingprofile
    {
        public string name { get; set; }
        public string ID { get; set; }
        public string href { get; set; }
    }

    public class Historyupdaily
    {
        public int[] val { get; set; }
    }

    public class Historydwdaily
    {
        public object[] val { get; set; }
    }

    public class Lrr
    {
        public string ID { get; set; }
        public float? lat { get; set; }
        public float? lon { get; set; }
        public float? RSSI { get; set; }
        public float? SNR { get; set; }
    }

}

namespace Kpn.LoRa.Client.Models.DeviceAddModel
{
    public class Device
    {
        //public string activation { get; set; }

        public string name { get; set; }

        public Model model { get; set; }

        public string EUI { get; set; }
        public string nwAddress { get; set; }
        public string nwKey { get; set; }
        public string appKeys { get; set; }

        public NetworkSubscription networkSubscription { get; set; }
        public AppServersRoutingProfile appServersRoutingProfile { get; set; }

        public string modelConfig { get; set; }
        public string customerAdminData { get; set; }
    }
    public class Model
    {
        public string ID { get; set; }
    }

    public class NetworkSubscription
    {
        public string ID { get; set; }
    }

    public class AppServersRoutingProfile
    {
        public string ID { get; set; }
    }


}

namespace Kpn.LoRa.Client.Models.DeviceUpdateModel
{
    public class Device
    {
        public string name { get; set; }
        public string nwKey { get; set; }
        public string appKeys { get; set; }

        public NetworkSubscription networkSubscription { get; set; }
        public AppServersRoutingProfile appServersRoutingProfile { get; set; }

        public string modelConfig { get; set; }
        public string customerAdminData { get; set; }
    }

    public class occContext
    {
        public string version { get; set; }
    }

    public class NetworkSubscription
    {
        public string ID { get; set; }
    }
    public class AppServersRoutingProfile
    {
        public string ID { get; set; }
    }
}