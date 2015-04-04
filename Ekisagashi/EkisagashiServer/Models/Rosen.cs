using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkisagashiServer.Models
{
    public class Rosen
    {
        public string RosenId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Eki> Eki { get; set; }
    }
}