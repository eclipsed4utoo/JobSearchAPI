using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI
{
    [XmlRoot(ElementName = "Money", IsNullable = true)]
    public class CareerBuilderPay
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string FormattedAmount { get; set; }
    }
}
