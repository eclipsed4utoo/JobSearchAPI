using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace JobSearchAPI.CareerBuilder
{
    [XmlRoot(ElementName = "Job", IsNullable = true)]
    public class CareerBuilderJobDetail
    {
        public string ApplyURL { get; set; }
        public string BeginDate { get; set; }
        public string BlankApplicationServiceURL { get; set; }
        public string Categories { get; set; }
        public string CategoriesCodes { get; set; }
        public string IndustryCodes { get; set; }
        public string Company { get; set; }
        public string CompanyURL { get; set; }
        public string CompanyDID { get; set; }
        public string CompanyJobSearchURL { get; set; }
        public string CompanyImageURL { get; set; }
        public string ContactInfoEmailURL { get; set; }
        public string ContactInfoFax { get; set; }
        public string ContactInfoName { get; set; }
        public string ContactInfoPhone { get; set; }
        public string DegreeRequired { get; set; }
        public string DegreeRequiredCode { get; set; }
        public string DID { get; set; }
        public string DisplayJobID { get; set; }
        public string Division { get; set; }
        public string EmploymentType { get; set; }
        public string EmploymentTypeCode { get; set; }
        public string EndDate { get; set; }
        public string ExperienceRequired { get; set; }
        public string ExperienceRequiredCode { get; set; }
        public string JobDescription { get; set; }
        public string JobRequirements { get; set; }
        public string JobTitle { get; set; }
        public string LocationStreet1 { get; set; }
        public string LocationStreet2 { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public string LocationFormatted { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string LocationMetroCity { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationState { get; set; }
        public string ManagesOthers { get; set; }
        public string ManagesOthersCode { get; set; }
        public string ModifiedDate { get; set; }
        public string ONetCode { get; set; }
        public string PayPer { get; set; }
        public string PayHighLowFormatted { get; set; }
        public string PrinterFriendlyURL { get; set; }
        public string RelocationCovered { get; set; }
        public string TravelRequired { get; set; }
        public string TravelRequiredCode { get; set; }
        public CareerBuilderPay PayHigh { get; set; }
        public CareerBuilderPay PayLow { get; set; }
        public CareerBuilderPay PayCommission { get; set; }
        public CareerBuilderPay PayBonus { get; set; }
        public CareerBuilderPay PayOther { get; set; }

        private WebClient client;

        public Task<CareerBuilderBlankApplication> GetBlankApplicationAsync()
        {
            if (string.IsNullOrWhiteSpace(this.BlankApplicationServiceURL))
                throw new InvalidOperationException("No Blank Application Service URL.");

            return Task.Factory.StartNew<CareerBuilderBlankApplication>(() =>
            {
                if (client == null)
                    client = new WebClient();

                var xmlData = client.DownloadString(this.BlankApplicationServiceURL);
                XDocument doc = XDocument.Parse(xmlData);
                var element = doc.Root.Element("BlankApplication");

                // if element is blank, job does not accept online applications
                if (element == null)
                    throw new ApplicationException("Job does not accept online applications");

                var application = XmlHelper.Deserialize<CareerBuilderBlankApplication>(element.ToString());

                var questions = element.Element("Questions");
                if (questions != null)
                {
                    application.Questions = new List<CareerBuilderApplicationQuestion>();

                    var qs = (from c in questions.Descendants("Question")
                             select c).ToList();

                    foreach (var question in qs)
                    {
                        application.Questions.Add(XmlHelper.Deserialize<CareerBuilderApplicationQuestion>(question.ToString()));
                    }
                }

                return application;
            });
        }
    }
}
