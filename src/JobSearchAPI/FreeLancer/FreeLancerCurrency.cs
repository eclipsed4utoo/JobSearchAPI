using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "currencyDetails", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerCurrency
    {
        [XmlElement(ElementName="id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "name", IsNullable = true)]
        public string Name { get; set; }

        [XmlElement(ElementName = "code", IsNullable = true)]
        public string Code { get; set; }

        [XmlElement(ElementName = "sign", IsNullable = true)]
        public string Sign { get; set; }

        [XmlElement(ElementName = "exchangerate")]
        public double ExchangeRate { get; set; }

        [XmlElement(ElementName = "country", IsNullable = true)]
        public string Country { get; set; }

        [XmlElement(ElementName = "seq")]
        public int Sequence { get; set; }
    }
}
