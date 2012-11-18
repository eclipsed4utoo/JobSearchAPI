using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI
{
    public abstract class JobSearchBase
    {
        public abstract string JobSearchWebServiceURL { get; }
    }
}
