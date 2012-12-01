using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    [XmlRoot(ElementName="listing", IsNullable = true)]
    public class AuthenticJobsJobPosting
    {
        [XmlAttribute(AttributeName="id")]
        public long ID { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "perks")]
        public string Perks { get; set; }
        [XmlAttribute(AttributeName = "howto_apply")]
        public string HowToApply { get; set; }
        [XmlAttribute(AttributeName = "post_date")]
        public string PostDate { get; set; }
        [XmlElement(ElementName="category", IsNullable=true)]
        public AuthenticJobsJobCategory Category { get; set; }
        [XmlElement(ElementName = "type", IsNullable = true)]
        public AuthenticJobsJobType JobType { get; set; }
        [XmlElement(ElementName = "company", IsNullable = true)]
        public AuthenticJobsCompany Company { get; set; }
    }
}
