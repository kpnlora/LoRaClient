using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.Models.Customers
{
    public class Customers
    {
        public Subscription subscription { get; set; }

        public User user { get; set; }
        
    }

    public class Subscription
    {
        public string href { get; set; }
    }

    public class User
    {
        public string firstName { get; set; }
        public string fastName { get; set; }
    }

}
