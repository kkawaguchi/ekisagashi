using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonSerializeDemo
{
    [System.Runtime.Serialization.DataContract]
    class InfoClass
    {
        [System.Runtime.Serialization.DataMember()]
        public int ID { get; set; }
        [System.Runtime.Serialization.DataMember()]
        public string Name { get; set; }

    }
}
