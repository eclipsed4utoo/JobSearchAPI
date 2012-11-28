using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "rating", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerRating
    {
        [XmlElement(ElementName="avg")]
        public int Average { get; set; }

        [XmlElement(ElementName="count")]
        public int Count { get; set; }
    }
}
