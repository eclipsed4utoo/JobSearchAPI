using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.AuthenticJobs
{
    public static class AuthenticJobsURLConstants
    {
        public static readonly string DEVELOPER_KEY = "api_key";
        public static readonly string METHOD = "method";
        public static readonly string CATEGORY = "category";
        public static readonly string JOB_TYPE = "type";
        public static readonly string SORT_OPTION = "sort";
        public static readonly string COMPANY = "company";
        public static readonly string LOCATION = "location";
        public static readonly string TELECOMMUTING = "telecommuting";
        public static readonly string KEYWORDS = "keywords";
        public static readonly string BEGIN_DATE = "begin_date";
        public static readonly string END_DATE = "end_date";
        public static readonly string PAGE = "page";
        public static readonly string PER_PAGE = "perpage";
    }

    public static class AuthenticJobsMethods
    {
        public static readonly string JOB_SEARCH = "aj.jobs.search";
        public static readonly string COMPANY_SEARCH = "aj.jobs.getCompanies";
        public static readonly string LOCATION_SEARCH = "aj.jobs.getLocations";
        public static readonly string JOB_TYPE_SEARCH = "aj.types.getList";
        public static readonly string JOB_CATEGORY_SEARCH = "aj.categories.getList";
        public static readonly string COMPANY_TYPE_SEARCH = "aj.company_types.getList";
    }

    public static class AuthenticJobsSortOptions
    {
        public static readonly string DATE_POSTED_DESC = "date_posted_desc";
        public static readonly string DATE_POSTED_ASC = "date_posted_asc";
    }
}
