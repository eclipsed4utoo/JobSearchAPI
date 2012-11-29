using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "buyer", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerBuyer : FreeLancerUser
    {
        [XmlElement(ElementName = "profile_logo_url", IsNullable = true)]
        public string ProfileLogoURL { get; set; }

        [XmlElement(ElementName = "currency")]
        public int Currency { get; set; }

        [XmlElement(ElementName = "timezone")]
        public int TimeZone { get; set; }
    }
}
