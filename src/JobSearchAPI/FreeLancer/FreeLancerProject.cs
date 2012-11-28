using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName = "project", IsNullable = true, Namespace = "http://api.freelancer.com/schemas/xml-0.1")]
    public class FreeLancerProject
    {
        [XmlElement(ElementName = "id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "name", IsNullable = true)]
        public string Name { get; set; }

        [XmlElement(ElementName = "url", IsNullable = true)]
        public string URL { get; set; }

        [XmlElement(ElementName = "start_date")]
        public string StartDate { get; set; }

        [XmlElement(ElementName = "end_date")]
        public string EndDate { get; set; }

        [XmlElement(ElementName = "buyer")]
        public FreeLancerBuyer Buyer { get; set; }

        [XmlElement(ElementName = "state", IsNullable = true)]
        public string ProjectState { get; set; }

        [XmlElement(ElementName = "closeDate")]
        public string CloseDate { get; set; }

        [XmlElement(ElementName = "short_descr", IsNullable = true)]
        public string ShortDescription { get; set; }

        [XmlElement(ElementName = "short_descr_html", IsNullable = true)]
        public string ShortDescriptionHTML { get; set; }

        [XmlElement(ElementName = "budget")]
        public FreeLancerBudget Budget { get; set; }

        [XmlElement(ElementName = "budgetPeriod", IsNullable = true)]
        public string BudgetPeriod { get; set; }

        [XmlElement(ElementName = "bid_stats")]
        public FreeLancerBidStats BidStats { get; set; }

        [XmlElement(ElementName = "currencyDetails")]
        public FreeLancerCurrency Currency { get; set; }

        [XmlElement(ElementName = "formatedState", IsNullable = true)]
        public string FormattedProjectState { get; set; }

        [XmlElement(ElementName = "daysLeft")]
        public int DaysLeft { get; set; }

        [XmlElement(ElementName = "hoursLeft")]
        public int HoursLeft { get; set; }

        [XmlElement(ElementName = "isHourly")]
        public bool IsHourly { get; set; }

        [XmlElement(ElementName = "opened")]
        public bool IsOpen { get; set; }

        [XmlElement(ElementName = "closed")]
        public bool IsClosed { get; set; }

        [XmlElement(ElementName = "closed_cancelled")]
        public bool WasClosedAndCancelled { get; set; }

        [XmlElement(ElementName = "closed_expired")]
        public bool WasClosedAndExpired { get; set; }

        [XmlElement(ElementName = "closed_accepted")]
        public bool WasClosedAndAccepted { get; set; }

        [XmlElement(ElementName = "frozen")]
        public bool IsFrozen { get; set; }

        [XmlElement(ElementName = "pending")]
        public bool IsPending { get; set; }

        [XmlElement(ElementName = "rejected")]
        public bool IsRejected { get; set; }
    }
}
