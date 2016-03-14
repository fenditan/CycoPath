using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycoPath.Models
{
    public class CycoPathModel
    {
        public Park ParkViewModel { get; set; }
        public Path PathViewModel { get; set; }
        public Weather WeatherViewModel { get; set; }
    }
}