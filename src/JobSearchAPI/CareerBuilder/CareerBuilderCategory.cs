using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "Category", IsNullable = true)]
    public class CareerBuilderCategory : CareerBuilderCode
    {
    }
}
