using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;

namespace JobSearchAPI.FreeLancer
{
    // API documentation at - http://apidocs.getafreelancer.com/
    public class FreeLancerJobSearch : JobSearchBase
    {
        private WebClient client;

        public override string JobSearchWebServiceURL
        {
            get { return "http://api.freelancer.com/Project/Search.xml"; }
        }

        public string ProjectWebServiceURL
        {
            get { return "http://api.freelancer.com/Project/"; }
        }

        public string UserWebServiceURL
        {
            get { return "http://api.freelancer.com/User/"; }
        }

        /// <summary>
        /// (Optional) - Used to specify the page number of results.  Defaults to 0, which is the first page of results
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// (Optional) - Used to specify the number of results returned.  Defaults to 50.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// (Optional) - Used to determine whether to search for Non Public projects only.  Defaults to return all projects.
        /// </summary>
        public bool? NonPublicProjectsOnly { get; set; }

        /// <summary>
        /// (Optional) - Limits the search to only projects by the specified Project Owner ID.
        /// </summary>
        public int Owner { get; set; }

        /// <summary>
        /// (Optional) - Limits the search to only projects by the specified Project Winner ID.
        /// </summary>
        public int Winner { get; set; }

        /// <summary>
        /// (Optional) - Limits the search to only projects in the specified job categories.
        /// </summary>
        public List<string> JobCategories { get; set; }

        /// <summary>
        /// (Optional) - Used to specify whether to limit by Featured or Non-Featured projects.  
        /// If not specified, returns both Featured and Non-Featured projects.
        /// </summary>
        public bool? FeaturedOnly { get; set; }

        /// <summary>
        /// (Optional) - Used to specify whether to limit by Trial or Non-Trial projects.  If not
        /// specified, returns both Trial and Non-Trial projects.
        /// </summary>
        public bool? TrialOnly { get; set; }

        /// <summary>
        /// (Optional) - Used to specify whether to limit by "For gold members" or Non-"For gold member
        /// projects.  If not specified, returns both both "For gold members" and Non-"For gold member" projects.
        /// </summary>
        public bool? GoldMembersOnly { get; set; }

        /// <summary>
        /// (Optional) - Only returns projects where the minimum budget is greater than or equal to the 
        /// specified value.  Valid values are multiples of 1000.
        /// </summary>
        public int MinimumBudget { get; set; }

        /// <summary>
        /// (Optional) - Only returns projects where the maximum budget is less than or equal to the 
        /// specified value.  Valid values are multiples of 1000.
        /// </summary>
        public int MaximumBudget { get; set; }

        /// <summary>
        /// (Optional) - Only returns projects ending sooner than specified value.
        /// </summary>
        public int BiddingEndsDays { get; set; }

        /// <summary>
        /// Sets the ordering of the results.  Defaults to Relevance.  Use FreeLancerSortFields for valid values.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Sets the sort direction of the results. Defaults to Descending. Use FreeLancerSortDirection for valid values.
        /// </summary>
        public string OrderDirection { get; set; }

        public FreeLancerJobSearch()
        {
            client = new WebClient();
            this.JobCategories = new List<string>();
        }

        public FreeLancerJobSearch(string developerKey)
            : this()
        {
            _developerKey = developerKey;
        }

        public Task<List<FreeLancerProjectPosting>> GetProjectsAsync()
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

        public Task<FreeLancerProject> GetProjectAsync(int projectID)
        {
            return Task.Factory.StartNew<FreeLancerProject>(() =>
            {
                FreeLancerProject project = null;

                string projectURL = this.ProjectWebServiceURL + projectID + ".xml";
                string url = CreateURLWithDeveloperKey(projectURL);
                var xmlData = client.DownloadString(url);

                project = XmlHelper.Deserialize<FreeLancerProject>(xmlData);

                return project;
            });
        }

        public Task<FreeLancerUser> GetUserAsync(int userID)
        {
            return Task.Factory.StartNew<FreeLancerUser>(() =>
            {
                FreeLancerUser user = null;

                string projectURL = this.UserWebServiceURL + userID + ".xml";
                string url = CreateURLWithDeveloperKey(projectURL);
                var xmlData = client.DownloadString(url);

                user = XmlHelper.Deserialize<FreeLancerUser>(xmlData);

                return user;
            });
        }

        private string CreateURL()
        {
            string url = this.JobSearchWebServiceURL;

            url += string.Format("?{0}={1}", FreeLancerURLConstants.PAGE_NUMBER, this.PageNumber);

            if (this.Count == 0)
                this.Count = 50;

            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.COUNT, this.Count);
            URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.DEVELOPER_KEY, _developerKey);

            if(this.NonPublicProjectsOnly.HasValue)
                URLHelper.ConcatenateURLParameters<int?>(ref url, FreeLancerURLConstants.NO_PUBLIC_PROJECTS_ONLY, (this.NonPublicProjectsOnly.Value) ? 1 : 0);

            URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.KEYWORD, Uri.EscapeDataString(this.Keywords));
            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.OWNER, this.Owner);
            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.WINNER, this.Winner);

            if (this.JobCategories.Count > 0)
            {
                foreach (var cat in this.JobCategories)
                {
                    URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.JOBS, cat);
                }
            }

            if (this.FeaturedOnly.HasValue)
                URLHelper.ConcatenateURLParameters<int?>(ref url, FreeLancerURLConstants.FEATURED, (this.FeaturedOnly.Value) ? 1 : 0);

            if (this.TrialOnly.HasValue)
                URLHelper.ConcatenateURLParameters<int?>(ref url, FreeLancerURLConstants.TRIAL, (this.TrialOnly.Value) ? 1 : 0);

            if (this.GoldMembersOnly.HasValue)
                URLHelper.ConcatenateURLParameters<int?>(ref url, FreeLancerURLConstants.FOR_GOLD_MEMBERS, (this.GoldMembersOnly.Value) ? 1 : 0);

            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.MIN_BUDGET, this.MinimumBudget);
            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.MAX_BUDGET, this.MaximumBudget);
            URLHelper.ConcatenateURLParameters<int>(ref url, FreeLancerURLConstants.BIDDING_ENDS, this.BiddingEndsDays);
            URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.ORDER, this.OrderBy);
            URLHelper.ConcatenateURLParameters<string>(ref url, FreeLancerURLConstants.ORDER_DIRECTION, this.OrderDirection);

            return url;
        }

        private string CreateURLWithDeveloperKey(string url)
        {
            if (string.IsNullOrWhiteSpace(_developerKey))
                return url;
            else
                return string.Format("{0}?{1}={2}", url, FreeLancerURLConstants.DEVELOPER_KEY, _developerKey);
        }
    }
}
