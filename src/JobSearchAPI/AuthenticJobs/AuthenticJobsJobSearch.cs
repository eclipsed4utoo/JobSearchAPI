using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobSearchAPI.AuthenticJobs
{
    //API Documentation - http://www.authenticjobs.com/api/documentation/
    public class AuthenticJobsJobSearch : JobSearchBase
    {
        private WebClient client = null;
        private string _developerKey = string.Empty;

        public override string JobSearchWebServiceURL
        {
            get { return "http://www.authenticjobs.com/api/"; }
        }

        public AuthenticJobsJobSearch(string developerKey)
        {
            _developerKey = developerKey;
            client = new WebClient();
            this.Sort = AuthenticJobsSortOptions.DATE_POSTED_DESC;
        }

        /// <summary>
        /// The id of a job category to limit to.  Use AuthenticJobsJobCategory for
        /// valid values.
        /// </summary>
        public int? JobCategory { get; set; }

        /// <summary>
        /// The id of a job type to limit to.  Use AuthenticJobsJobType for valid values.
        /// </summary>
        public int? JobType { get; set; }

        /// <summary>
        /// Defines the sort order.  Use AuthenticJobsSortOptions for valid values.  Defaults to 
        /// AuthenticJobsSortOptions.DATE_POSTED_DESC.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Free-text matching against company names. Suggested values are the ids from AuthenticJobsCompany.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Free-text matching against company location names. Suggested values are the ids from AuthenticJobsLocation.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Set to true for only telecommuting jobs
        /// </summary>
        public bool? Telecommuting { get; set; }

        /// <summary>
        /// Keywords to look for in the title or description of the job posting. 
        /// Separate multiple keywords with commas. Multiple keywords will be treated as an OR
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Listings posted before this time will not be returned.
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Listings posted after this time will not be returned.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The page of listings to return. Defaults to 1.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The number of listings per page. The default value is 10. The maximum value is 100.
        /// </summary>
        public int? PerPage { get; set; }

        /// <summary>
        /// Returns a list of supported job types. Caching is recommended.
        /// </summary>
        /// <returns></returns>
        public Task<List<AuthenticJobsJobType>> GetJobTypesAsync()
        {
            return Task.Factory.StartNew<List<AuthenticJobsJobType>>(() =>
            {
                List<AuthenticJobsJobType> jobTypes = new List<AuthenticJobsJobType>();

                var url = CreateJobTypeSearchURL();
                var xmlData = client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("types").Descendants("type")
                               select c).ToList();

                foreach (var job in results)
                {
                    jobTypes.Add(XmlHelper.Deserialize<AuthenticJobsJobType>(job.ToString()));
                }

                return jobTypes;
            });
        }

        /// <summary>
        /// Returns a list of supported job categories.  Caching is recommended.
        /// </summary>
        /// <returns></returns>
        public Task<List<AuthenticJobsJobCategory>> GetJobCategoriesAsync()
        {
            return Task.Factory.StartNew<List<AuthenticJobsJobCategory>>(() =>
            {
                List<AuthenticJobsJobCategory> jobCategories = new List<AuthenticJobsJobCategory>();

                var url = CreateJobCategorySearchURL();
                var xmlData = client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("categories").Descendants("category")
                               select c).ToList();

                foreach (var job in results)
                {
                    jobCategories.Add(XmlHelper.Deserialize<AuthenticJobsJobCategory>(job.ToString()));
                }

                return jobCategories;
            });
        }

        /// <summary>
        /// Returns a list of supported company types.  Caching is recommended.
        /// </summary>
        /// <returns></returns>
        public Task<List<AuthenticJobsCompanyType>> GetCompanyTypesAsync()
        {
            return Task.Factory.StartNew<List<AuthenticJobsCompanyType>>(() =>
            {
                List<AuthenticJobsCompanyType> companyTypes = new List<AuthenticJobsCompanyType>();

                var url = CreateCompanyTypeSearchURL();
                var xmlData = client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("company_types").Descendants("company_type")
                               select c).ToList();

                foreach (var job in results)
                {
                    companyTypes.Add(XmlHelper.Deserialize<AuthenticJobsCompanyType>(job.ToString()));
                }

                return companyTypes;
            });
        }

        /// <summary>
        /// Returns a list of current positions, filtered by optional parameters. 
        /// </summary>
        /// <returns></returns>
        public Task<List<AuthenticJobsJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<List<AuthenticJobsJobPosting>>(() =>
            {
                List<AuthenticJobsJobPosting> jobs = new List<AuthenticJobsJobPosting>();

                var url = CreateJobSearchURL();
                var xmlData = client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("listings").Descendants("listing")
                               select c).ToList();

                foreach (var job in results)
                {
                    jobs.Add(XmlHelper.Deserialize<AuthenticJobsJobPosting>(job.ToString()));
                }

                return jobs;
            });
        }

        public Task<List<AuthenticJobsLocation>> GetLocationsAsync()
        {
            return Task.Factory.StartNew<List<AuthenticJobsLocation>>(() =>
            {
                List<AuthenticJobsLocation> locations = new List<AuthenticJobsLocation>();

                var url = CreateLocationSearchURL();
                var xmlData = client.DownloadString(url);

                XDocument doc = XDocument.Parse(xmlData);

                var results = (from c in doc.Root.Element("locations").Descendants("location")
                               select c).ToList();

                foreach (var location in results)
                {
                    locations.Add(XmlHelper.Deserialize<AuthenticJobsLocation>(location.ToString()));
                }

                return locations;
            });
        }

        private string CreateJobSearchURL()
        {
            string url = CreateURLWithDeveloperKey(this.JobSearchWebServiceURL);

            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.METHOD, AuthenticJobsMethods.JOB_SEARCH);
            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.CATEGORY, this.JobCategory);
            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.JOB_TYPE, this.JobType);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.SORT_OPTION, this.Sort);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.COMPANY, this.Company);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.LOCATION, this.Location);
            URLHelper.ConcatenateURLParameters<bool?>(ref url, AuthenticJobsURLConstants.TELECOMMUTING, this.Telecommuting);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.KEYWORDS, this.Keywords);

            if (this.BeginDate.HasValue)
                URLHelper.ConcatenateURLParameters<double>(ref url, AuthenticJobsURLConstants.BEGIN_DATE, ConvertToTimestamp(this.BeginDate.Value));

            if (this.EndDate.HasValue)
                URLHelper.ConcatenateURLParameters<double>(ref url, AuthenticJobsURLConstants.END_DATE, ConvertToTimestamp(this.EndDate.Value));

            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.PAGE, this.Page);
            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.PER_PAGE, this.PerPage);

            return url;
        }

        private string CreateLocationSearchURL()
        {
            string url = CreateURLWithDeveloperKey(this.JobSearchWebServiceURL);

            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.METHOD, AuthenticJobsMethods.LOCATION_SEARCH);
            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.CATEGORY, this.JobCategory);
            URLHelper.ConcatenateURLParameters<int?>(ref url, AuthenticJobsURLConstants.JOB_TYPE, this.JobType);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.SORT_OPTION, this.Sort);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.COMPANY, this.Company);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.LOCATION, this.Location);
            URLHelper.ConcatenateURLParameters<bool?>(ref url, AuthenticJobsURLConstants.TELECOMMUTING, this.Telecommuting);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.KEYWORDS, this.Keywords);

            if (this.BeginDate.HasValue)
                URLHelper.ConcatenateURLParameters<double>(ref url, AuthenticJobsURLConstants.BEGIN_DATE, ConvertToTimestamp(this.BeginDate.Value));

            if (this.EndDate.HasValue)
                URLHelper.ConcatenateURLParameters<double>(ref url, AuthenticJobsURLConstants.END_DATE, ConvertToTimestamp(this.EndDate.Value));

           return url;
        }

        private string CreateJobTypeSearchURL()
        {
            string url = CreateURLWithDeveloperKey(this.JobSearchWebServiceURL);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.METHOD, AuthenticJobsMethods.JOB_TYPE_SEARCH);
            return url;
        }

        private string CreateJobCategorySearchURL()
        {
            string url = CreateURLWithDeveloperKey(this.JobSearchWebServiceURL);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.METHOD, AuthenticJobsMethods.JOB_CATEGORY_SEARCH);
            return url;
        }

        private string CreateCompanyTypeSearchURL()
        {
            string url = CreateURLWithDeveloperKey(this.JobSearchWebServiceURL);
            URLHelper.ConcatenateURLParameters<string>(ref url, AuthenticJobsURLConstants.METHOD, AuthenticJobsMethods.COMPANY_TYPE_SEARCH);
            return url;
        }

        private string CreateURLWithDeveloperKey(string url)
        {
            return string.Format("{0}?{1}={2}", url, AuthenticJobsURLConstants.DEVELOPER_KEY, _developerKey);
        }

        private double ConvertToTimestamp(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (double)span.TotalSeconds;
        }
    }
}
