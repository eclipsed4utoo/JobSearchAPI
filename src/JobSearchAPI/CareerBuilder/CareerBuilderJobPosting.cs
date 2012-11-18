using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "JobSearchResult", IsNullable = true)]
    public class CareerBuilderJobPosting
    {
        public string Company { get; set; }
        public string CompanyDID { get; set; }
        public string CompanyDetailsURL { get; set; }
        public string DID { get; set; }
        public string OnetCode { get; set; }
        public string DescriptionTeaser { get; set; }
        public string Distance { get; set; }
        public string EmploymentType { get; set; }
        public string JobDetailsURL { get; set; }
        public string JobServiceURL { get; set; }
        public string Location { get; set; }
        [XmlElement("LocationLatitude")]
        public double Latitude { get; set; }
        [XmlElement("LocationLongitude")]
        public double Longitude { get; set; }
        public string PostedDate { get; set; }
        public string Pay { get; set; }
        public string SimilarJobsURL { get; set; }
        public string JobTitle { get; set; }
        public string CompanyImageURL { get; set; }

        private WebClient client = null;

        public Task<CareerBuilderJobDetail> GetJobDetailAsync()
        {
            if (string.IsNullOrWhiteSpace(this.JobServiceURL))
                throw new InvalidOperationException("No Job Service URL");

            return Task.Factory.StartNew<CareerBuilderJobDetail>(() =>
            {
                if (client == null)
                    client = new WebClient();

                var xmlData = client.DownloadString(this.JobServiceURL);

                XDocument doc = XDocument.Parse(xmlData);

                var element = doc.Root.Element("Job");

                var detail = XmlHelper.Deserialize<CareerBuilderJobDetail>(element.ToString());

                var payHigh = element.Element("PayHigh").Element("Money");
                if (payHigh != null)
                    detail.PayHigh = XmlHelper.Deserialize<CareerBuilderPay>(payHigh.ToString());

                var payLow = element.Element("PayLow").Element("Money");
                if (payLow != null)
                    detail.PayLow = XmlHelper.Deserialize<CareerBuilderPay>(payLow.ToString());

                var payCommission = element.Element("PayCommission").Element("Money");
                if (payCommission != null)
                    detail.PayCommission = XmlHelper.Deserialize<CareerBuilderPay>(payCommission.ToString());

                var payBonus = element.Element("PayBonus").Element("Money");
                if (payBonus != null)
                    detail.PayBonus = XmlHelper.Deserialize<CareerBuilderPay>(payBonus.ToString());

                var payOther = element.Element("PayOther").Element("Money");
                if (payOther != null)
                    detail.PayOther = XmlHelper.Deserialize<CareerBuilderPay>(payOther.ToString());

                return detail;
            });
        }
    }
}
