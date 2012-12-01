using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobSearchAPI.AuthenticJobs
{
    [XmlRoot(ElementName="type", IsNullable=true)]
    public class AuthenticJobsJobType : AuthenticJobsType
    {
    }
}
