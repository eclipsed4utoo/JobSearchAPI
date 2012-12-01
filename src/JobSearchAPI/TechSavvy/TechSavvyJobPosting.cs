using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JobSearchAPI.TechSavvy
{
    public class TechSavvyJobPosting
    {
        [JsonProperty(PropertyName="title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "date_listed")]
        public string DateListed { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty(PropertyName = "contacts")]
        public List<string> Contacts { get; set; }
        [JsonProperty(PropertyName = "md5")]
        public string MD5 { get; set; }
        [JsonProperty(PropertyName = "posted")]
        public string Posted { get; set; }
    }
}
