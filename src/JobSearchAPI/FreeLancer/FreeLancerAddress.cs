using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "address", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerAddress
    {
        [XmlElement(ElementName="country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }
    }
}
