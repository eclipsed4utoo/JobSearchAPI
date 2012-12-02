using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.Dice
{
    public class DiceJobPosting
    {
        public string JobTitle { get; set; }
        public string JobURL { get; set; }
        public string Company { get; set; }
        public string CompanyURL { get; set; }
        public string Location { get; set; }
        public string PostedDate { get; set; }
    }
}
