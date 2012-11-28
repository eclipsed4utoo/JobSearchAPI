using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.FreeLancer
{
    public static class FreeLancerURLConstants
    {
        public static readonly string DEVELOPER_KEY = "apikey";
        public static readonly string PAGE_NUMBER = "pg";
        public static readonly string COUNT = "count";
        public static readonly string NO_PUBLIC_PROJECTS_ONLY = "nonpublic";
        public static readonly string KEYWORD = "keyword";
        public static readonly string OWNER = "owner";
        public static readonly string WINNER = "winner";
        public static readonly string JOBS = "jobs[]";
        public static readonly string FEATURED = "featured";
        public static readonly string TRIAL = "trial";
        public static readonly string FOR_GOLD_MEMBERS = "for_gold_members";
        public static readonly string MIN_BUDGET = "min_budget";
        public static readonly string MAX_BUDGET = "max_budget";
        public static readonly string BIDDING_ENDS = "bidding_ends";
        public static readonly string ORDER = "order";
        public static readonly string ORDER_DIRECTION = "order_dir";
    }

    public class FreeLancerSortDirection
    {
        public static readonly string ASCENDING = "asc";
        public static readonly string DESCENDING = "desc";
    }

    public class FreeLancerSortFields
    {
        public static readonly string ID = "id";
        public static readonly string SUBMIT_DATE = "submitdate";
        public static readonly string STATE = "state";
        public static readonly string BID_COUNT = "bid_count";
        public static readonly string BID_AVERAGE = "bid_average";
        public static readonly string BID_END_DATE = "bid_enddate";
        public static readonly string BUYER = "buyer";
        public static readonly string BUDGET = "budget";
        public static readonly string RANDOM = "rand";
        public static readonly string RELEVANCE = "relevance";
    }
}
