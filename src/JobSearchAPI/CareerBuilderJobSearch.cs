using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Xml;

namespace JobSearchAPI
{
    public class CareerBuilderJobSearch : JobSearchBase
    {
        private string _developerKey = string.Empty;

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
        }

        public Task<IEnumerable<CareerBuilderJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<IEnumerable<CareerBuilderJobPosting>>(() =>
            {
                List<CareerBuilderJobPosting> jobs = new List<CareerBuilderJobPosting>();

                WebClient client = new WebClient();
                var data = client.DownloadString(this.WebServiceURL);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                string json = JsonConvert.SerializeXmlNode(doc);

                

                return jobs;
            });
        }
    }
}
