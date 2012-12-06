using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI
{
    public abstract class JobSearchBase
    {
        internal string _developerKey;

        internal JobSearchBase() { }

        internal JobSearchBase(string developerKey)
        {
            _developerKey = developerKey;
        }

        public abstract string JobSearchWebServiceURL { get; }

        /// <summary>
        /// Limits the search by the specified keywords.
        /// </summary>
        public string Keywords { get; set; }
    }
}
