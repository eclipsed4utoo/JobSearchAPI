using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    public class AuthenticJobsException : Exception
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
