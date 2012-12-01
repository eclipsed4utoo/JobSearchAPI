using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JobSearchAPI.TechSavvy
{
    public class TechSavvyJobSearch : JobSearchBase
    {
        private WebClient client = null;

        public override string JobSearchWebServiceURL
        {
            get { return "http://api.techsavvy.io/jobs"; }
        }

        /// <summary>
        /// Limits the job search to the specified number of results. Defaults to 50.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Keywords to limit the job search
        /// </summary>
        public string Keywords { get; set; }

        public TechSavvyJobSearch()
        {
            client = new WebClient();
            this.Limit = 50;
        }

        public Task<List<TechSavvyJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<List<TechSavvyJobPosting>>(() =>
            {
                List<TechSavvyJobPosting> jobs = new List<TechSavvyJobPosting>();

                var url = CreateURL();
                var data = client.DownloadString(url);

                JObject allData = JObject.Parse(data);
                JArray jobData = (JArray)allData["data"];

                foreach (var job in jobData)
                {
                    jobs.Add(JsonConvert.DeserializeObject<TechSavvyJobPosting>(job.ToString()));
                }

                return jobs;
            });
        }

        private string CreateURL()
        {
            string url = this.JobSearchWebServiceURL;

            if (!string.IsNullOrWhiteSpace(this.Keywords))
            {
                url += string.Format("/{0}?{1}={2}", Uri.EscapeDataString(this.Keywords).Replace(" ", "+"), TechSavvyURLConstants.LIMIT, this.Limit);
            }
            else
            {
                url += string.Format("?{0}={1}", TechSavvyURLConstants.LIMIT, this.Limit);
            }

            return url;
        }
    }
}
