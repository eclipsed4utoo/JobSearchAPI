using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "item", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerProjectPosting : FreeLancerProject
    {
        
    }
}
