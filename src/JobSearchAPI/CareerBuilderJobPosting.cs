﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JobSearchAPI
{
    public class CareerBuilderJobPosting
    {
        public string Company { get; set; }
        public string CompanyDID { get; set; }
        public string CompanyDetailsURL { get; set; }
        public string DID { get; set; }
        public string OnetCode { get; set; }
        public string DescriptionTeaser { get; set; }
        public string Distance { get; set; }
        public string EmploymentType { get; set; }
        public string JobDetailsURL { get; set; }
        public string JobServiceURL { get; set; }
        public string Location { get; set; }
        [JsonProperty("LocationLatitude")]
        public double Latitude { get; set; }
        [JsonProperty("LocationLongitude")]
        public double Longitude { get; set; }
        public string PostedDate { get; set; }
        public string Pay { get; set; }
        public string SimilarJobsURL { get; set; }
        public string JobTitle { get; set; }
        public string CompanyImageURL { get; set; }
    }
}
