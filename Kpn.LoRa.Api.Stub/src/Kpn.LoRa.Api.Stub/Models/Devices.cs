using System;
using System.Collections.Generic;
using System.Linq;


namespace Kpn.LoRa.Api.Stub.Models.Devices
{
    public class Devices
    {
        public Brief[] briefs { get; set; }
        public bool more { get; set; }
        public long now { get; set; }
    }

    public class Brief
    {
        public string name { get; set; }
        public Model model { get; set; }
        public string EUI { get; set; }
        public string nwAddress { get; set; }
        public Networksubscription networkSubscription { get; set; }
        public int markerID { get; set; }
        public long? lastUpTimestamp { get; set; }
        public long? lastDwTimestamp { get; set; }
        public float? lastRSSI { get; set; }
        public float? lastSNR { get; set; }
        public float? avgRSSI { get; set; }
        public float? avgSNR { get; set; }
        public int? lastSF { get; set; }
        public object lastBatLevel { get; set; }
        public int alarmCount { get; set; }
        public int alarmLevel { get; set; }
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

namespace Kpn.LoRa.Api.Stub.Models.Device
{

    public class Device
    {
        public long now { get; set; }
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
        public int markerID { get; set; }
        public object alarm004 { get; set; }
        public long firstUpTimestamp { get; set; }
        public long lastUpTimestamp { get; set; }
        public object lastDwTimestamp { get; set; }
        public float lastRSSI { get; set; }
        public float lastSNR { get; set; }
        public float avgRSSI { get; set; }
        public float avgSNR { get; set; }
        public int lastSF { get; set; }
        public object lastBatLevel { get; set; }
        public object lastBatLevelTimestamp { get; set; }
        public object lastBatChanged { get; set; }
        public object lastBatChangeBy { get; set; }
        public Historyupdaily historyUpDaily { get; set; }
        public Historydwdaily historyDwDaily { get; set; }
        public int alarm6 { get; set; }
        public int alarm5 { get; set; }
        public int alarm4 { get; set; }
        public int alarm3 { get; set; }
        public int alarm2 { get; set; }
        public int alarm1 { get; set; }
        public float lastGeoLat { get; set; }
        public float lastGeoLon { get; set; }
        public object lastGeoRadius { get; set; }
        public long lastGeoTimestamp { get; set; }
        public object adminLat { get; set; }
        public object adminLon { get; set; }
        public int locationType { get; set; }
        public Lrr[] LRRs { get; set; }
    }

    public class Occcontext
    {
        public int version { get; set; }
        public long lastUpdate { get; set; }
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
        public float lat { get; set; }
        public float lon { get; set; }
        public float RSSI { get; set; }
        public float SNR { get; set; }
    }
}