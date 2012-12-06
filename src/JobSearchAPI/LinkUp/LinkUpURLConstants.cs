using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.LinkUp
{
    internal static class LinkUpURLConstants
    {
        public static readonly string DEVELOPER_KEY = "api_key";
        public static readonly string EMBEDDED_SEARCH_KEY = "embedded_search_key";
        public static readonly string IP_ADDRESS = "orig_ip";
        public static readonly string COMPANY = "company";
        public static readonly string FILTER_TYPE = "filter_type";
        public static readonly string DESC_LENGTH = "desc_length";
        public static readonly string DISTANCE = "distance";
        public static readonly string GROUP_COMPANIES = "group_companies";
        public static readonly string HIGHLIGHT_PARAM = "highlight_param";
        public static readonly string KEYWORD = "keyword";
        public static readonly string LOCATION = "location";
        public static readonly string LIST = "list";
        public static readonly string REQUIRE_LOCATION = "require_location";
        public static readonly string PAGE = "page";
        public static readonly string SORT = "sort";
        public static readonly string INCLUDE_ORGANIC = "include_organic";
        public static readonly string PER_PAGE = "per_page";
        public static readonly string INCLUDE_ADS = "include_ads";
        public static readonly string SPONSORED_PER_PAGE = "sponsored_per_page";
        public static readonly string TAGS = "tags";
        public static readonly string TIME_FRAME = "time_frame";
    }

    public static class LinkUpTimeFrameOptions
    {
        public static readonly string ONE_DAY = "1d";
        public static readonly string THREE_DAYS = "3d";
        public static readonly string SEVEN_DAYS = "7d";
        public static readonly string FOURTEEN_DAYS = "14d";
        public static readonly string ALL = "ALL";
    }

    public static class LinkUpSortOptions
    {
        public static readonly string DATE = "d";
        public static readonly string RELEVANCE = "r";
    }

    public static class LinkUpFilterTypeOptions
    {
        public static readonly string INCLUDE = "include";
        public static readonly string EXCLUDE = "exclude";
    }
}
