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

        public override string JobSearchWebServiceURL
        {
            get { return "http://api.careerbuilder.com/v1/jobsearch"; }
        }

        public string CategoriesWebServiceURL
        {
            get { return "http://api.careerbuilder.com/v1/categories"; }
        }

        public string EducationCodesWebServiceURL
        {
            get { return "http://api.careerbuilder.com/v1/educationcodes";  }
        }

        public string EmployeeTypesWebServiceURL
        {
            get { return "http://api.careerbuilder.com/v1/employeetypes"; }
        }

        /// <summary>
        /// If true, the search will not be constrained by CountryCode or HostSite.
        /// </summary>
        public bool SearchAllCountries { get; set; }

        /// <summary>
        /// Filters jobs to match criteria for relocation. If not supplied, results returned will be results
        /// with 'null' as their relocation data.
        /// </summary>
        public bool RelocateJobs { get; set; }

        /// <summary>
        /// The search radius size (in miles) around a specified location. 
        /// Must be one of: 5, 10, 20, 30, 50, 100, 150. If no value is provided, defaults to 30.
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// Must be one of: 1, 3, 7, or 30. If no value is provided, defaults to 30. 
        /// Filters the results list to contain only jobs posted with the provided number of days.
        /// </summary>
        public int PostedWithinDays { get; set; }

        /// <summary>
        /// Sets page size.  Defaults to 25.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Retrieves a specific page of results
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Sets the ordering of the results.  Defaults to Relevance.  Use CareerBuilderSortFields for valid values.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Sets the sort direction of the results. Defaults to Descending. Use CareerBuilderSortDirection for valid values.
        /// </summary>
        public string OrderDirection { get; set; }

        /// <summary>
        /// Returns only jobs with the provided job title in their title. 
        /// Use quote-marks if you have multiple words with spaces and want to match the exact string.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Returns a results set that is related to the supplied keywords. Single value or comma-separated list.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// If true, the result set will also contain jobs from child companies of the specified 
        /// company given in the CompanyName, CompanyNameCSV, or CompanyDID.
        /// </summary>
        public bool IncludeCompanyChildren { get; set; }

        /// <summary>
        /// If true, a set of facets describing the search results is returned in addition to the set of results.
        /// </summary>
        public bool UseFacets { get; set; }

        /// <summary>
        /// *UseFacets must be set to true for this to be considered* 
        /// Accepts a single Company Title that must be encased in double quotes ("Company Name"). 
        /// Limits the job search to a particulair company.
        /// </summary>
        public string FacetCompany { get; set; }

        /// <summary>
        /// *UseFacets must be set to true for this to be considered* 
        /// Accepts a single Job Category value. 
        /// Limits the job search to jobs that fall under a particulair category.
        /// </summary>
        public string FacetCategory { get; set; }

        /// <summary>
        /// *UseFacets must be set to true for this to be considered* 
        /// Accepts a single City and will limit the job search to that area.
        /// </summary>
        public string FacetCity { get; set; }

        /// <summary>
        /// *UseFacets must be set to true for this to be considered* 
        /// Accepts a denoted two letter State and will limit the job search to that area.
        /// </summary>
        public string FacetState { get; set; }

        /// <summary>
        /// *UseFacets must be set to true for this to be considered* 
        /// Accepts a single value in the form of a City and denoted two letter State value delimited by a comma. 
        /// This will limit the job search to that area.
        /// </summary>
        public string FacetCityState { get; set; }

        /// <summary>
        /// Can accept a single value, or a comma-separated list of values.
        /// </summary>
        public string EmployeeType { get; set; }

        /// <summary>
        /// Limits the Job Search by the Education Code. By default, returns specified Education Code 
        /// and lower.  For exact match, set SpecificEducation to true.
        /// </summary>
        public string EducationCode { get; set; }

        /// <summary>
        /// Will limit the Job Search to companies whose names contain the value provided.
        /// Use quote-marks if you have multiple words with spaces and want to match the exact string
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Limits the Job Search to jobs from the supplied CompanyDIDs
        /// </summary>
        public string CompanyDIDCSV { get; set; }

        /// <summary>
        /// Limits the Job Search to jobs from the supplied CompanyDID.
        /// </summary>
        public string CompanyDID { get; set; }

        /// <summary>
        /// Limits search for the specified country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Limits search for the specified location. Allows City, City/State, or ZipCode.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Use this param to set change how the keywords are joined together. If no value is provided, defaults to AND. 
        /// Optionally use CareerBuilderBooleanOperators class for valid values.
        /// </summary>
        public string BooleanOperator { get; set; }

        /// <summary>
        /// Can accept a single value, or a comma-separated list of values (maximum 10). 
        /// If the given value(s) do not match any of CareeerBuilder's category names or category codes, 
        /// this parameter is ignored.
        /// </summary>
        public string Category { get; set; }

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

                var url = CreateURL();
                var data = client.DownloadString(url);

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

        public Task<List<CareerBuilderEmployeeType>> GetJobSearchEmployeeTypesAsync()
        {
            return GetJobSearchEmployeeTypesAsync(string.Empty);
        }

        public Task<List<CareerBuilderEmployeeType>> GetJobSearchEmployeeTypesAsync(string countryCode)
        {
            return Task.Factory.StartNew<List<CareerBuilderEmployeeType>>(() =>
            {
                var typeList = new List<CareerBuilderEmployeeType>();
                string url = CreateURLWithDeveloperKey(this.EmployeeTypesWebServiceURL);

                var xmlData = client.DownloadString(url);
                var doc = XDocument.Parse(xmlData);

                var types = (from c in doc.Root.Element("EmployeeTypes").Descendants("EmployeeType")
                             select c).ToList();

                foreach (var type in types)
                {
                    typeList.Add(XmlHelper.Deserialize<CareerBuilderEmployeeType>(type.ToString()));
                }

                return typeList;
            });
        }

        public Task<List<CareerBuilderEducationCode>> GetJobSearchEducationCodesAsync()
        {
            return GetJobSearchEducationCodesAsync(string.Empty);
        }

        public Task<List<CareerBuilderEducationCode>> GetJobSearchEducationCodesAsync(string countryCode)
        {
            return Task.Factory.StartNew<List<CareerBuilderEducationCode>>(() =>
            {
                var codesList = new List<CareerBuilderEducationCode>();
                string url = CreateURLWithDeveloperKey(this.EducationCodesWebServiceURL);

                var xmlData = client.DownloadString(url);
                var doc = XDocument.Parse(xmlData);

                var codes = (from c in doc.Root.Element("EducationCodes").Descendants("Education")
                             select c).ToList();

                foreach (var code in codes)
                {
                    codesList.Add(XmlHelper.Deserialize<CareerBuilderEducationCode>(code.ToString()));
                }

                return codesList;
            });
        }

        public Task<List<CareerBuilderCategory>> GetJobSearchCategoriesAsync()
        {
            return GetJobSearchCategoriesAsync(string.Empty);
        }

        public Task<List<CareerBuilderCategory>> GetJobSearchCategoriesAsync(string countryCode)
        {
            return Task.Factory.StartNew<List<CareerBuilderCategory>>(() =>
            {
                var categoryList = new List<CareerBuilderCategory>();
                string url = CreateURLWithDeveloperKey(this.CategoriesWebServiceURL);

                if (!string.IsNullOrWhiteSpace(countryCode))
                    url += string.Format("&{0}={1}", CareerBuilderURLConstants.COUNTRY_CODE, countryCode);

                var xmlData = client.DownloadString(url);
                var doc = XDocument.Parse(xmlData);

                var categories = (from c in doc.Root.Element("Categories").Descendants("Category")
                                  select c).ToList();

                foreach (var category in categories)
                {
                    categoryList.Add(XmlHelper.Deserialize<CareerBuilderCategory>(category.ToString()));
                }

                return categoryList;
            });
        }

        private string CreateURL()
        {
            string url = this.JobSearchWebServiceURL;

            url += string.Format("?{0}={1}", CareerBuilderURLConstants.DEVELOPER_KEY, _developerKey);

            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.COUNTRY_CODE, this.Country);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.LOCATION, this.Location);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.BOOLEAN_OPERATOR, this.BooleanOperator);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.CATEGORY, this.Category);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.COMPANY_DID, this.CompanyDID);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.COMPANY_DID_CSV, this.CompanyDIDCSV);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.COMPANY_NAME, this.CompanyName);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.EDUCATION_CODE, this.EducationCode);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.EMP_TYPE, this.EmployeeType);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.FACET_CATEGORY, this.FacetCategory);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.FACET_CITY, this.FacetCity);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.FACET_CITY_STATE, this.FacetCityState);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.FACET_COMPANY, this.FacetCompany);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.FACET_STATE, this.FacetState);
            ConcatenateURLParameters<bool>(ref url, CareerBuilderURLConstants.USE_FACETS, this.UseFacets);
            ConcatenateURLParameters<bool>(ref url, CareerBuilderURLConstants.INCLUDE_COMPANY_CHILDREN, this.IncludeCompanyChildren);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.JOB_TITLE, this.JobTitle);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.KEYWORDS, this.Keywords);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.ORDER_BY, this.OrderBy);
            ConcatenateURLParameters<string>(ref url, CareerBuilderURLConstants.ORDER_DIRECTION, this.OrderDirection);
            ConcatenateURLParameters<int>(ref url, CareerBuilderURLConstants.PER_PAGE, this.PerPage);
            ConcatenateURLParameters<int>(ref url, CareerBuilderURLConstants.PAGE_NUMBER, this.PageNumber);
            ConcatenateURLParameters<int>(ref url, CareerBuilderURLConstants.POSTED_WITHIN, this.PostedWithinDays);
            ConcatenateURLParameters<int>(ref url, CareerBuilderURLConstants.RADIUS, this.Radius);
            ConcatenateURLParameters<bool>(ref url, CareerBuilderURLConstants.RELOCATE_JOBS, this.RelocateJobs);
            ConcatenateURLParameters<bool>(ref url, CareerBuilderURLConstants.SEARCH_ALL_COUNTRIES, this.SearchAllCountries);

            return url;
        }

        private void ConcatenateURLParameters<T>(ref string url, string parameterName, T parameterValue)
        {
            var defaultValue = default(T);

            if (typeof(string) == typeof(T))
                defaultValue = (T)Convert.ChangeType(string.Empty, typeof(T));

            if (defaultValue == null || parameterValue == null || parameterValue.Equals(defaultValue))
                return;

            url = string.Format("{0}&{1}={2}", url, parameterName, parameterValue);
        }

        private string CreateURLWithDeveloperKey(string url)
        {
            return string.Format("{0}?{1}={2}", url, CareerBuilderURLConstants.DEVELOPER_KEY, _developerKey);
        }
    }
}
