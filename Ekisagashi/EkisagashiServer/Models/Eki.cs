using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkisagashiServer.Models
{
    public class Eki
    {
        public int EkiId { get; set; }
        public string Name { get; set; }
        public int RosenId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}