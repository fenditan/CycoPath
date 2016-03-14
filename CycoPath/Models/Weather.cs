﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycoPath.Models
{
    public class Weather
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Forecast { get; set; }
        public string Icon { get; set; }
        public string Zone { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}