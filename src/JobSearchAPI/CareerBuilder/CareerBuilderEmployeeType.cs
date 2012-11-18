using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "EmployeeType", IsNullable = true)]
    public class CareerBuilderEmployeeType : CareerBuilderCode
    {
    }
}
