using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.LinkUp
{
    [XmlRoot(ElementName="job", IsNullable=true)]
    public class LinkUpJobPosting
    {
        [XmlElement(ElementName="job_title", IsNullable=true)]
        public string JobTitle { get; set; }
        [XmlElement(ElementName = "job_title_link", IsNullable = true)]
        public string JobLink { get; set; }
        [XmlElement(ElementName = "job_company", IsNullable = true)]
        public string Company { get; set; }
        [XmlElement(ElementName = "job_tag", IsNullable = true)]
        public string Tag { get; set; }
        [XmlElement(ElementName = "job_location", IsNullable = true)]
        public string Location { get; set; }
        [XmlElement(ElementName = "job_zip", IsNullable = true)]
        public string Zip { get; set; }
        [XmlElement(ElementName = "job_date_added", IsNullable = true)]
        public string DateAdded { get; set; }
        [XmlElement(ElementName = "job_description", IsNullable = true)]
        public string Description { get; set; }
        [XmlElement(ElementName = "job_country", IsNullable = true)]
        public string Country { get; set; }
    }
}
