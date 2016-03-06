using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycoPath.Models
{
    public class Path
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IdData { get; set; }

        public string ConnectorName { get; set; }

        public string Description { get; set; }
        public string StyleURl { get; set; }
        public string altMode { get; set; }
        public string Coordinates { get; set; }
    }
}