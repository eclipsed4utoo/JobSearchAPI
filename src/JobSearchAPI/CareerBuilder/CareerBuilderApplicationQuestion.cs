using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "Question", IsNullable = true)]
    public class CareerBuilderApplicationQuestion
    {
        public string QuestionID { get; set; }
        public string QuestionType { get; set; }
        public bool IsRequired { get; set; }
        public string ExpectedResponseFormat { get; set; }
        public string QuestionText { get; set; }
    }
}
