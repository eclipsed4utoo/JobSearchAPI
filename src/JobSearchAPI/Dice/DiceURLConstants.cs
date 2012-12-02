using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.Dice
{
    public static class DiceURLConstants
    {
        public static readonly string PER_PAGE = "NUM_PER_PAGE";
        public static readonly string DAYS_BACK = "DAYSBACK";
        public static readonly string KEYWORD = "FREE_TEXT";
        public static readonly string LOCATION = "WHERE";
        public static readonly string PAGE_NUMBER = "No";
        public static readonly string TELECOMMUTING = "N";
        public static readonly string VIEW_TYPE = "FRMT";
        public static readonly string SORT_FIELD = "Ns";
        public static readonly string SORT_DIRECTION = "SORTDIR";
    }

    internal static class DiceTelecommutingOptions
    {
        public static readonly string ALL = "1100";
        public static readonly string NO_TELECOMMUTING = "1101";
        public static readonly string TELECOMMUTING_ONLY = "1102";
    }

    internal static class DiceViewTypes
    {
        public static readonly string SUMMARY = "0";
        public static readonly string DETAIL = "1";
    }

    internal static class DiceSortFields
    {
        public static readonly string POSTED_DATE = "p_PostedAge|0";
    }

    internal static class DiceSortDirection
    {
        public static readonly string DESCENDING = "7";
    }
}
