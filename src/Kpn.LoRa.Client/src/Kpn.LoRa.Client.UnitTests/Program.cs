﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kpn.LoRa.Client.UnitTests
{
    public class Program
    {


        public static void Main(string[] args)
        {
            //workbench          
            var tests = new ClientToStubTests("", "", "", "");
            tests.GetCustomersTest();
        }
    }
}