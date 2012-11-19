using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="bid_stats", IsNullable=true)]
    public class FreeLancerBidStats
    {
        [XmlElement(ElementName = "count", IsNullable = true)]
        public int Count { get; set; }

        [XmlElement(ElementName = "avg", IsNullable = true)]
        public int AverageBid { get; set; }
    }
}
