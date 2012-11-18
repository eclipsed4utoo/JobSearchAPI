using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace JobSearchAPI
{
    public class CareerBuilderJobSearch : JobSearchBase
    {
        private string _developerKey = string.Empty;
        private WebClient client = null;

        public override string WebServiceURL
        {
            get { return "http://api.careerbuilder.com/v1/jobsearch"; }
        }

        /// <summary>
        /// Limits search for the specified country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Limits search for the specified location. Allows City, City/State, or ZipCode.
        /// </summary>
        public string Location { get; set; }

        public CareerBuilderJobSearch(string developerKey)
        {
            if (string.IsNullOrWhiteSpace(developerKey))
                throw new ArgumentException("Developer Key is empty.", "developerKey");

            _developerKey = developerKey;
            client = new WebClient();
        }

        public Task<IEnumerable<CareerBuilderJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<IEnumerable<CareerBuilderJobPosting>>(() =>
            {
                List<CareerBuilderJobPosting> jobs = new List<CareerBuilderJobPosting>();

                var data = client.DownloadString(CreateURL());

                XDocument doc = XDocument.Parse(data);
                
                var results = (from c in doc.Root.Element("Results").Descendants("JobSearchResult")
                              select c).ToList();

                foreach (var result in results)
                {   
                    jobs.Add(XmlHelper.Deserialize<CareerBuilderJobPosting>(result.ToString()));
                }

                return jobs;
            });
        }

        private string CreateURL()
        {
            string url = this.WebServiceURL;

            url += string.Format("?{0}={1}", CareerBuilderURLConstants.DEVELOPER_KEY, _developerKey);

            if (!string.IsNullOrWhiteSpace(this.Country))
                url += string.Format("&{0}={1}", CareerBuilderURLConstants.COUNTRY_CODE, this.Country);

            if (!string.IsNullOrWhiteSpace(this.Location))
                url += string.Format("&{0}={1}", CareerBuilderURLConstants.LOCATION, this.Location);

            return url;
        }
    }
}
