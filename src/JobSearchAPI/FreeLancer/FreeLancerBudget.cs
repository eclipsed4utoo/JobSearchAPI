using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "budget", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerBudget
    {
        [XmlElement(ElementName="min")]
        public int Min { get; set; }

        [XmlElement(ElementName="max")]
        public int Max { get; set; }
    }
}
