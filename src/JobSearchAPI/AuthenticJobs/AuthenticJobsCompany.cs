using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    [XmlRoot(ElementName="company", IsNullable=true)]
    public class AuthenticJobsCompany
    {
        [XmlAttribute(AttributeName = "id")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string URL { get; set; }
        public AuthenticJobsLocation Location { get; set; }
    }
}
