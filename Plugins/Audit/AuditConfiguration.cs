﻿using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreMonarchy.Audit
{
    public class AuditConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string APIUrl { get; set; }
        public string APIKey { get; set; }
        public double RefreshInterval { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "orange";
            APIUrl = "http://servers.restoremonarchy.com/api";
            APIKey = "APIKEY";
            RefreshInterval = 30000;
        }
    }
}
