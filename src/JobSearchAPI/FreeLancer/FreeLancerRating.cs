using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="rating", IsNullable=true)]
    public class FreeLancerRating
    {
        [XmlElement(ElementName="avg", IsNullable=true)]
        public int Average { get; set; }

        [XmlElement(ElementName="count", IsNullable=true)]
        public int Count { get; set; }
    }
}
