using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kpn.LoRa.Api.Stub.Payload
{

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.actility.com/lora")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://uri.actility.com/lora", IsNullable = false)]
    public partial class DevEUI_uplink
    {

        private System.DateTime timeField;

        private string devEUIField;

        private byte fPortField;

        private byte fCntUpField;

        private byte fCntDnField;

        private string payload_hexField;

        private string mic_hexField;

        private byte lrcidField;

        private decimal lrrRSSIField;

        private decimal lrrSNRField;

        private byte spFactField;

        private string subBandField;

        private string channelField;

        private byte devLrrCntField;

        private string lrridField;

        private decimal lrrLATField;

        private decimal lrrLONField;

        private DevEUI_uplinkLrrs lrrsField;

        private uint customerIDField;

        private string customerDataField;

        /// <remarks/>
        public System.DateTime Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        public string DevEUI
        {
            get
            {
                return this.devEUIField;
            }
            set
            {
                this.devEUIField = value;
            }
        }

        /// <remarks/>
        public byte FPort
        {
            get
            {
                return this.fPortField;
            }
            set
            {
                this.fPortField = value;
            }
        }

        /// <remarks/>
        public byte FCntUp
        {
            get
            {
                return this.fCntUpField;
            }
            set
            {
                this.fCntUpField = value;
            }
        }

        /// <remarks/>
        public byte FCntDn
        {
            get
            {
                return this.fCntDnField;
            }
            set
            {
                this.fCntDnField = value;
            }
        }

        /// <remarks/>
        public string payload_hex
        {
            get
            {
                return this.payload_hexField;
            }
            set
            {
                this.payload_hexField = value;
            }
        }

        /// <remarks/>
        public string mic_hex
        {
            get
            {
                return this.mic_hexField;
            }
            set
            {
                this.mic_hexField = value;
            }
        }

        /// <remarks/>
        public byte Lrcid
        {
            get
            {
                return this.lrcidField;
            }
            set
            {
                this.lrcidField = value;
            }
        }

        /// <remarks/>
        public decimal LrrRSSI
        {
            get
            {
                return this.lrrRSSIField;
            }
            set
            {
                this.lrrRSSIField = value;
            }
        }

        /// <remarks/>
        public decimal LrrSNR
        {
            get
            {
                return this.lrrSNRField;
            }
            set
            {
                this.lrrSNRField = value;
            }
        }

        /// <remarks/>
        public byte SpFact
        {
            get
            {
                return this.spFactField;
            }
            set
            {
                this.spFactField = value;
            }
        }

        /// <remarks/>
        public string SubBand
        {
            get
            {
                return this.subBandField;
            }
            set
            {
                this.subBandField = value;
            }
        }

        /// <remarks/>
        public string Channel
        {
            get
            {
                return this.channelField;
            }
            set
            {
                this.channelField = value;
            }
        }

        /// <remarks/>
        public byte DevLrrCnt
        {
            get
            {
                return this.devLrrCntField;
            }
            set
            {
                this.devLrrCntField = value;
            }
        }

        /// <remarks/>
        public string Lrrid
        {
            get
            {
                return this.lrridField;
            }
            set
            {
                this.lrridField = value;
            }
        }

        /// <remarks/>
        public decimal LrrLAT
        {
            get
            {
                return this.lrrLATField;
            }
            set
            {
                this.lrrLATField = value;
            }
        }

        /// <remarks/>
        public decimal LrrLON
        {
            get
            {
                return this.lrrLONField;
            }
            set
            {
                this.lrrLONField = value;
            }
        }

        /// <remarks/>
        public DevEUI_uplinkLrrs Lrrs
        {
            get
            {
                return this.lrrsField;
            }
            set
            {
                this.lrrsField = value;
            }
        }

        /// <remarks/>
        public uint CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        public string CustomerData
        {
            get
            {
                return this.customerDataField;
            }
            set
            {
                this.customerDataField = value;
            }
        }
    }

    /// <remarks/>

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.actility.com/lora")]
    public partial class DevEUI_uplinkLrrs
    {

        private DevEUI_uplinkLrrsLrr lrrField;

        /// <remarks/>
        public DevEUI_uplinkLrrsLrr Lrr
        {
            get
            {
                return this.lrrField;
            }
            set
            {
                this.lrrField = value;
            }
        }
    }

    /// <remarks/>

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://uri.actility.com/lora")]
    public partial class DevEUI_uplinkLrrsLrr
    {

        private string lrridField;

        private decimal lrrRSSIField;

        private decimal lrrSNRField;

        /// <remarks/>
        public string Lrrid
        {
            get
            {
                return this.lrridField;
            }
            set
            {
                this.lrridField = value;
            }
        }

        /// <remarks/>
        public decimal LrrRSSI
        {
            get
            {
                return this.lrrRSSIField;
            }
            set
            {
                this.lrrRSSIField = value;
            }
        }

        /// <remarks/>
        public decimal LrrSNR
        {
            get
            {
                return this.lrrSNRField;
            }
            set
            {
                this.lrrSNRField = value;
            }
        }
    }


}
