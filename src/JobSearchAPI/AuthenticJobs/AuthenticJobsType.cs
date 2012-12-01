using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    public abstract class AuthenticJobsType
    {
        [XmlAttribute(AttributeName = "id")]
        public int ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
