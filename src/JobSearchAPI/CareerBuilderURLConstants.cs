using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI
{
    internal static class CareerBuilderURLConstants
    {
        public static readonly string DEVELOPER_KEY = "DeveloperKey";
        public static readonly string ADVANCED_GROUPING_MODE = "AdvancedGroupingMode";
        public static readonly string BOOLEAN_OPERATOR = "BooleanOperator";
        public static readonly string COUNTRY_CODE = "CountryCode";
        public static readonly string LOCATION = "Location";
        public static readonly string CATEGORY = "Category";
        public static readonly string COMPANY_DID = "CompanyDID";
        public static readonly string COMPANY_DID_CSV = "CompanyDIDCSV";
        public static readonly string COMPANY_NAME = "CompanyName";
        public static readonly string EDUCATION_CODE = "EducationCode";
        public static readonly string EMP_TYPE = "EmpType";
        public static readonly string FACET_COMPANY = "FacetCompany";
        public static readonly string FACET_CATEGORY = "FacetCategory";
        public static readonly string FACET_CITY = "FacetCity";
        public static readonly string FACET_STATE = "FacetState";
        public static readonly string FACET_CITY_STATE = "FacetCityState";
        public static readonly string USE_FACETS = "UseFacets";
        public static readonly string INCLUDE_COMPANY_CHILDREN = "IncludeCompanyChildren";
        public static readonly string JOB_TITLE = "JobTitle";
        public static readonly string KEYWORDS = "Keywords";
        public static readonly string ORDER_BY = "OrderBy";
        public static readonly string ORDER_DIRECTION = "OrderDirection";
        public static readonly string PAGE_NUMBER = "PageNumber";
        public static readonly string PER_PAGE = "PerPage";
        public static readonly string POSTED_WITHIN = "PostedWithin";
        public static readonly string RADIUS = "Radius";
        public static readonly string RELOCATE_JOBS = "RelocateJobs";
        public static readonly string SEARCH_ALL_COUNTRIES = "SearchAllCountries";
    }

    public class CareerBuilderBooleanOperators
    {
        public static readonly string AND = "AND";
        public static readonly string OR = "OR";
    }

    public class CareerBuilderSortFields
    {
        public static readonly string DATE = "Date";
        public static readonly string PAY = "Pay";
        public static readonly string TITLE = "Title";
        public static readonly string COMPANY = "Company";
        public static readonly string DISTANCE = "Distance";
        public static readonly string LOCATION = "Location";
        public static readonly string RELEVANCE = "Relevance";
    }

    public class CareerBuilderSortDirection
    {
        public static readonly string ASCENDING = "ASC";
        public static readonly string DESCENDING = "DESC";
    }

    public class CareerBuilderCountryCodes
    {  
        public static readonly string AH = "AH";
        public static readonly string BE = "BE";
        public static readonly string CA = "CA";
        public static readonly string CC = "CC";
        public static readonly string CE = "CE";
        public static readonly string CH = "CH";
        public static readonly string CN = "CN";
        public static readonly string CP = "CP";
        public static readonly string CS = "CS";
        public static readonly string CY = "CY";
        public static readonly string DE = "DE";
        public static readonly string DK = "DK";
        public static readonly string E1 = "E1";
        public static readonly string ER = "ER";
        public static readonly string ES = "ES";
        public static readonly string EU = "EU";
        public static readonly string F1 = "F1";
        public static readonly string FR = "FR";
        public static readonly string GC = "GC";
        public static readonly string GR = "GR";
        public static readonly string I1 = "I1";
        public static readonly string IE = "IE";
        public static readonly string IN = "IN";
        public static readonly string IT = "IT";
        public static readonly string JC = "JC";
        public static readonly string JS = "JS";
        public static readonly string LJ = "LJ";
        public static readonly string M1 = "M1";
        public static readonly string MY = "MY";
        public static readonly string NL = "NL";
        public static readonly string NO = "NO";
        public static readonly string PD = "PD";
        public static readonly string PI = "PI";
        public static readonly string PL = "PL";
        public static readonly string RM = "RM";
        public static readonly string RO = "RO";
        public static readonly string RX = "RX";
        public static readonly string S1 = "S1";
        public static readonly string SE = "SE";
        public static readonly string SF = "SF";
        public static readonly string SG = "SG";
        public static readonly string T2 = "T2";
        public static readonly string UK = "UK";
        public static readonly string US = "US";
        public static readonly string WH = "WH";
        public static readonly string WM = "WM";
        public static readonly string WR = "WR";
    }
}
