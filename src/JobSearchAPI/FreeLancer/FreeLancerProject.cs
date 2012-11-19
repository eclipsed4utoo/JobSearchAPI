using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.FreeLancer
{
    [XmlRoot(ElementName="project", IsNullable=true)]
    public class FreeLancerProject
    {
        [XmlElement(ElementName = "id", IsNullable = true)]
        public int ID { get; set; }

        [XmlElement(ElementName = "name", IsNullable = true)]
        public string Name { get; set; }

        [XmlElement(ElementName = "url", IsNullable = true)]
        public string URL { get; set; }

        [XmlElement(ElementName = "start_date", IsNullable = true)]
        public DateTime StartDate { get; set; }

        [XmlElement(ElementName = "end_date", IsNullable = true)]
        public DateTime EndDate { get; set; }

        [XmlElement(ElementName = "buyer", IsNullable = true)]
        public FreeLancerBuyer Buyer { get; set; }

        [XmlElement(ElementName = "state", IsNullable = true)]
        public string ProjectState { get; set; }

        [XmlElement(ElementName = "closeDate", IsNullable = true)]
        public DateTime CloseDate { get; set; }

        [XmlElement(ElementName = "short_descr", IsNullable = true)]
        public string ShortDescription { get; set; }

        [XmlElement(ElementName = "short_descr_html", IsNullable = true)]
        public string ShortDescriptionHTML { get; set; }

        [XmlElement(ElementName = "budget", IsNullable = true)]
        public FreeLancerBudget Budget { get; set; }

        [XmlElement(ElementName = "budgetPeriod", IsNullable = true)]
        public string BudgetPeriod { get; set; }

        [XmlElement(ElementName = "bid_stats", IsNullable = true)]
        public FreeLancerBidStats BidStats { get; set; }

        [XmlElement(ElementName = "currencyDetails", IsNullable = true)]
        public FreeLancerCurrency Currency { get; set; }

        [XmlElement(ElementName = "formatedState", IsNullable = true)]
        public string FormattedProjectState { get; set; }

        [XmlElement(ElementName = "daysLeft", IsNullable = true)]
        public int DaysLeft { get; set; }

        [XmlElement(ElementName = "hoursLeft", IsNullable = true)]
        public int HoursLeft { get; set; }

        [XmlElement(ElementName = "isHourly", IsNullable = true)]
        public bool IsHourly { get; set; }

        [XmlElement(ElementName = "opened", IsNullable = true)]
        public bool IsOpen { get; set; }

        [XmlElement(ElementName = "closed", IsNullable = true)]
        public bool IsClosed { get; set; }

        [XmlElement(ElementName = "closed_cancelled", IsNullable = true)]
        public bool WasClosedAndCancelled { get; set; }

        [XmlElement(ElementName = "closed_expired", IsNullable = true)]
        public bool WasClosedAndExpired { get; set; }

        [XmlElement(ElementName = "closed_accepted", IsNullable = true)]
        public bool WasClosedAndAccepted { get; set; }

        [XmlElement(ElementName = "frozen", IsNullable = true)]
        public bool IsFrozen { get; set; }

        [XmlElement(ElementName = "pending", IsNullable = true)]
        public bool IsPending { get; set; }

        [XmlElement(ElementName = "rejected", IsNullable = true)]
        public bool IsRejected { get; set; }
    }
}
