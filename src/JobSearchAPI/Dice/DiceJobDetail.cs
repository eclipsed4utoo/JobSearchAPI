using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchAPI.Dice
{
    public class DiceJobDetail
    {
        public string Location { get; set; }
        public string AreaCode { get; set; }
        public string Telecommute { get; set; }
        public string TravelRequired { get; set; }
        public string Skills { get; set; }
        public string PayRate { get; set; }
        public string TaxTerm { get; set; }
        public string Length { get; set; }
        public string DatePosted { get; set; }
        public string PositionID { get; set; }
        public string DiceID { get; set; }
        public string Description { get; set; }
    }
}
