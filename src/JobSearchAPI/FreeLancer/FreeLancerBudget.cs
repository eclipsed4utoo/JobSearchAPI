using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="budget", IsNullable=true)]
    public class FreeLancerBudget
    {
        [XmlElement(ElementName="min", IsNullable=true)]
        public int Min { get; set; }

        [XmlElement(ElementName="max", IsNullable=true)]
        public int Max { get; set; }
    }
}
