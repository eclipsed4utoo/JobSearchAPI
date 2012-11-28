using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "bid_stats", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerBidStats
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "avg")]
        public int AverageBid { get; set; }
    }
}
