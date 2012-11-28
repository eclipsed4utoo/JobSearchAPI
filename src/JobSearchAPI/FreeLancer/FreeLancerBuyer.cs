using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "buyer", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerBuyer
    {
        [XmlElement(ElementName="url", IsNullable=true)]
        public string URL { get; set; }

        [XmlElement(ElementName = "id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "username", IsNullable = true)]
        public string UserName { get; set; }

        [XmlElement(ElementName = "logo_url", IsNullable = true)]
        public string LogoURL { get; set; }

        [XmlElement(ElementName = "profile_logo_url", IsNullable = true)]
        public string ProfileLogoURL { get; set; }

        [XmlElement(ElementName = "reg_date")]
        public string RegistrationDate { get; set; }

        [XmlElement(ElementName = "company", IsNullable = true)]
        public string Company { get; set; }

        [XmlElement(ElementName = "currency")]
        public int Currency { get; set; }

        [XmlElement(ElementName = "timezone")]
        public int TimeZone { get; set; }

        [XmlElement(ElementName = "gold")]
        public int Gold { get; set; }

        [XmlElement(ElementName = "address")]
        public FreeLancerAddress Address { get; set; }

        [XmlElement(ElementName = "hourlyrate")]
        public double HourlyRate { get; set; }

        [XmlElement(ElementName = "rating")]
        public FreeLancerRating Rating { get; set; }

        [XmlElement(ElementName = "provider_rating")]
        public FreeLancerRating ProviderRating { get; set; }

        [XmlElement(ElementName = "buyer_rating")]
        public FreeLancerRating BuyerRating { get; set; }
    }
}
