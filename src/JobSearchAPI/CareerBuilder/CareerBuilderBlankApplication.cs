using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "BlankApplication", IsNullable = true)]
    public class CareerBuilderBlankApplication
    {
        public string ApplicationSubmitServiceURL { get; set; }
        public string ApplyURL { get; set; }
        public string JobDID { get; set; }
        public string JobTitle { get; set; }
        public CareerBuilderApplicationRequirements Requirements { get; set; }
        public string TotalQuestions { get; set; }
        public string TotalRequiredQuestions { get; set; }
        public List<CareerBuilderApplicationQuestion> Questions { get; set; }
    }
}
