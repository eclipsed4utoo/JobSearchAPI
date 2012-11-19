using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="buyer", IsNullable=true)]
    public class FreeLancerBuyer
    {
        [XmlElement(ElementName="url", IsNullable=true)]
        public string URL { get; set; }

        [XmlElement(ElementName = "id", IsNullable = true)]
        public int ID { get; set; }

        [XmlElement(ElementName = "username", IsNullable = true)]
        public string UserName { get; set; }

        [XmlElement(ElementName = "logo_url", IsNullable = true)]
        public string LogoURL { get; set; }

        [XmlElement(ElementName = "profile_logo_url", IsNullable = true)]
        public string ProfileLogoURL { get; set; }

        [XmlElement(ElementName = "reg_date", IsNullable = true)]
        public DateTime RegistrationDate { get; set; }

        [XmlElement(ElementName = "company", IsNullable = true)]
        public string Company { get; set; }

        [XmlElement(ElementName = "currency", IsNullable = true)]
        public int Currency { get; set; }

        [XmlElement(ElementName = "timezone", IsNullable = true)]
        public int TimeZone { get; set; }

        [XmlElement(ElementName = "gold", IsNullable = true)]
        public int Gold { get; set; }

        [XmlElement(ElementName = "address", IsNullable = true)]
        public FreeLancerAddress Address { get; set; }

        [XmlElement(ElementName = "hourlyrate", IsNullable = true)]
        public double HourlyRate { get; set; }

        [XmlElement(ElementName = "rating", IsNullable = true)]
        public FreeLancerRating Rating { get; set; }

        [XmlElement(ElementName = "provider_rating", IsNullable = true)]
        public FreeLancerRating ProviderRating { get; set; }

        [XmlElement(ElementName = "buyer_rating", IsNullable = true)]
        public FreeLancerRating BuyerRating { get; set; }
    }
}
