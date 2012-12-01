using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    [XmlRoot(ElementName="location", IsNullable = true)]
    public class AuthenticJobsLocation
    {
        [XmlAttribute(AttributeName="id")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "city")]
        public string City { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
        [XmlAttribute(AttributeName = "lat")]
        public double Latitude { get; set; }
        [XmlAttribute(AttributeName = "lng")]
        public double Longitude { get; set; }
    }
}
