using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycoPath.Models
{
    public class Park
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string DescriptionAndPostalCode { get; set; }

        public string Coordinates { get; set; }
    }
}