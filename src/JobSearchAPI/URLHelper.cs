using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI
{
    public static class URLHelper
    {
        public static void ConcatenateURLParameters<T>(ref string url, string parameterName, T parameterValue)
        {
            var defaultValue = default(T);

            if (typeof(string) == typeof(T))
                defaultValue = (T)Convert.ChangeType(string.Empty, typeof(T));

            if (defaultValue == null || parameterValue == null || parameterValue.Equals(defaultValue))
                return;

            url = string.Format("{0}&{1}={2}", url, parameterName, parameterValue);
        }
    }
}
