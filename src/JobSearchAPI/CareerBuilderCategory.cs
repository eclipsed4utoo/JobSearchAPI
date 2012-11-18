using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI
{
    [XmlRoot(ElementName = "Category", IsNullable = true)]
    public class CareerBuilderCategory
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
