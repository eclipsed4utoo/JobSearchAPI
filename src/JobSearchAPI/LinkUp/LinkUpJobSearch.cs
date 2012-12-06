using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobSearchAPI.LinkUp
{
    //API Documentation - http://secure.linkup.com/developers/
    public class LinkUpJobSearch : JobSearchBase
    {
        private WebClient _client = null;
        private string _embeddedSearchKey = string.Empty;

        public override string JobSearchWebServiceURL
        {
            get { return "http://www.linkup.com/developers/v-1/search-handler.js"; }
        }

        /// <summary>
        /// The IP address of the end user initiating search against the API.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Limit results to jobs with this company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Defined whether to include or exclude the company_ids.  Defaults to 'exclude'. Use
        /// LinkUpFilterTypeOptions for valid options.
        /// </summary>
        public string FilterType { get; set; }

        /// <summary>
        /// Number of alpha-numeric characters, excluding highlight parameter markup, to include in the feed.
        /// Defaults to 255.
        /// </summary>
        public int DescriptionLength { get; set; }

        /// <summary>
        /// Distance from search location (miles or km, depending on country standard unit). "e" for exact match.
        /// Defaults to 25.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Optionally limit the jobs to just 1 (or whatever int) per company.
        /// </summary>
        public bool GroupCompanies { get; set; }

        /// <summary>
        /// HTML tag used to wrap matching words. 
        /// </summary>
        public string HighlightParameter { get; set; }

        /// <summary>
        /// Search location. Zip code or "city, state".
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Pre-defined company list as setup in developer options.
        /// </summary>
        public string List { get; set; }

        /// <summary>
        /// Only include jobs that map to a specific address.
        /// </summary>
        public bool RequireLocation { get; set; }

        /// <summary>
        /// Page number of the results to return. Defaults to 1.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Sorts the results by Date or Relevance.  Use LinkUpSortOptions for valid values.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Boolean value, enabled by default, to include non-ads in results. Defaults to true.
        /// </summary>
        public bool IncludeOrganic { get; set; }

        /// <summary>
        /// Number of organic jobs to return per page. Defaults to 20.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Boolean value, enabled by default, to include ads in results.
        /// </summary>
        public bool IncludeAds { get; set; }

        /// <summary>
        /// Number of sponsored jobs to return per page. Defaults to 2.
        /// </summary>
        public int SponsoredPerPage { get; set; }

        /// <summary>
        /// List of tags to search within. Multiple tags may be joined by semi-colons.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// How many days back to search.  Use LinkUpTimeFrameOptions for valid values.
        /// </summary>
        public string TimeFrame { get; set; }

        public LinkUpJobSearch(string developerKey, string embeddedSearchKey, string ipAddress)
            : base(developerKey)
        {
            _client = new WebClient();
            _embeddedSearchKey = embeddedSearchKey;
            this.IPAddress = ipAddress;
        }

        public Task<List<LinkUpJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<List<LinkUpJobPosting>>(() =>
            {
                List<LinkUpJobPosting> jobs = new List<LinkUpJobPosting>();

                string url = CreateURL();
                var xmlData = _client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("jobs").Descendants("job")
                               select c).ToList();

                //TODO: get sponsored listings

                foreach (var job in results)
                {
                    jobs.Add(XmlHelper.Deserialize<LinkUpJobPosting>(job.ToString()));
                }

                return jobs;
            });
        }

        private string CreateURL()
        {
            string url = CreateURLWithRequiredParameters(this.JobSearchWebServiceURL);

            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.COMPANY, this.Company);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.FILTER_TYPE, this.FilterType);
            URLHelper.ConcatenateURLParameters<int>(ref url, LinkUpURLConstants.DESC_LENGTH, this.DescriptionLength);
            URLHelper.ConcatenateURLParameters<int>(ref url, LinkUpURLConstants.DISTANCE, this.Distance);
            URLHelper.ConcatenateURLParameters<bool>(ref url, LinkUpURLConstants.GROUP_COMPANIES, this.GroupCompanies);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.HIGHLIGHT_PARAM, this.HighlightParameter);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.KEYWORD, this.Keywords);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.LOCATION, this.Location);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.LIST, this.List);
            URLHelper.ConcatenateURLParameters<bool>(ref url, LinkUpURLConstants.REQUIRE_LOCATION, this.RequireLocation);
            URLHelper.ConcatenateURLParameters<int>(ref url, LinkUpURLConstants.PAGE, this.Page);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.SORT, this.Sort);
            URLHelper.ConcatenateURLParameters<bool>(ref url, LinkUpURLConstants.INCLUDE_ORGANIC, this.IncludeOrganic);
            URLHelper.ConcatenateURLParameters<int>(ref url, LinkUpURLConstants.PER_PAGE, this.PerPage);
            URLHelper.ConcatenateURLParameters<bool>(ref url, LinkUpURLConstants.INCLUDE_ADS, this.IncludeAds);
            URLHelper.ConcatenateURLParameters<int>(ref url, LinkUpURLConstants.SPONSORED_PER_PAGE, this.SponsoredPerPage);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.TAGS, this.Tags);
            URLHelper.ConcatenateURLParameters<string>(ref url, LinkUpURLConstants.TIME_FRAME, this.TimeFrame);

            return url;
        }

        private string CreateURLWithRequiredParameters(string url)
        {
            return string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", url, LinkUpURLConstants.DEVELOPER_KEY, _developerKey, LinkUpURLConstants.EMBEDDED_SEARCH_KEY, _embeddedSearchKey, LinkUpURLConstants.IP_ADDRESS, this.IPAddress);
        }
    }
}
