using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="address", IsNullable=true)]
    public class FreeLancerAddress
    {
        [XmlElement(ElementName="country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }
    }
}
