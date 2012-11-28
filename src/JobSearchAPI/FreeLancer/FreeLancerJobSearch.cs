using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;

namespace JobSearchAPI.FreeLancer
{
    public class FreeLancerJobSearch : JobSearchBase
    {
        private WebClient client;
        private string _developerKey;

        public override string JobSearchWebServiceURL
        {
            get { return "http://api.freelancer.com/Project/Search.xml"; }
        }

        public string ProjectWebServiceURL
        {
            get { return "http://api.freelancer.com/Project/"; }
        }

        /// <summary>
        /// Used to specify the page number of results.  Defaults to 0, which is the first page of results
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Used to specify the number of results returned.  Defaults to 50.
        /// </summary>
        public int Count { get; set; }

        public FreeLancerJobSearch()
        {
            client = new WebClient();
        }

        public FreeLancerJobSearch(string developerKey)
            : this()
        {
            _developerKey = developerKey;
        }

        public Task<List<FreeLancerProjectPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<List<FreeLancerProjectPosting>>(() =>
            {
                List<FreeLancerProjectPosting> projectsList = new List<FreeLancerProjectPosting>();

                var url = CreateURL();
                var data = client.DownloadString(url);

                XDocument doc = XDocument.Parse(data);
                XNamespace ns = "http://api.freelancer.com/schemas/xml-0.1";

                var results = (from c in doc.Root.Element(ns + "items").Descendants(ns + "item")
                               select c).ToList();

                foreach (var result in results)
                {
                    projectsList.Add(XmlHelper.Deserialize<FreeLancerProjectPosting>(result.ToString()));
                }

                return projectsList;
            });
        }

        private string CreateURL()
        {
            string url = this.JobSearchWebServiceURL;

            url += string.Format("?{0}={1}", FreeLancerURLConstants.PAGE_NUMBER, this.PageNumber);

            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.COUNT, this.Count);
            URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.DEVELOPER_KEY, _developerKey);

            return url;
        }

        
    }
}
