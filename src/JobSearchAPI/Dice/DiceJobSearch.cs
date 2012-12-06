using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace JobSearchAPI.Dice
{
    public class DiceJobSearch : JobSearchBase
    {
        private WebClient client = null;

        public string RootURL
        {
            get { return "http://seeker.dice.com"; }
        }

        public override string JobSearchWebServiceURL
        {
            get { return "http://seeker.dice.com/jobsearch/servlet/JobSearch?op=300"; }
        }

        /// <summary>
        /// Specifies the number of results per page. Defaults to 30.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Specifies the number of days from the current day to show job postings.
        /// Defaults to 30 days.
        /// </summary>
        public int DaysBack { get; set; }

        /// <summary>
        /// Specifies the location of job postings.  This can be City, State, or Zip Code.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Specifies the page number of the results.  Defaults to first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Specifies whether to return only telecommuting jobs.  Default returns all.
        /// </summary>
        public bool? TelecommutingOnly { get; set; }

        public DiceJobSearch()
        {
            client = new WebClient();
            this.PerPage = 30;
        }

        public Task<List<DiceJobPosting>> GetJobsAsync()
        {
            return Task.Factory.StartNew<List<DiceJobPosting>>(() =>
            {
                List<DiceJobPosting> jobs = new List<DiceJobPosting>();

                var url = CreateURL();
                var htmlData = client.DownloadString(url);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlData);

                var jobRows = (from c in doc.DocumentNode.SelectNodes("//tr[@class='STDsrRes' or @class='gold']")
                            select c).ToList();

                DiceJobPosting job = null;

                foreach (var row in jobRows)
                {
                    job = new DiceJobPosting();
                    
                    var titleLinkNode = row.Descendants("a").ElementAt(0);
                    var companyLinkNode = row.Descendants("a").ElementAt(1);
                    job.JobTitle = titleLinkNode.InnerText;
                    job.JobURL = this.RootURL + titleLinkNode.Attributes[0].Value.Replace("amp;", "");
                    job.Company = companyLinkNode.InnerText;
                    job.CompanyURL = this.RootURL + companyLinkNode.Attributes[0].Value.Replace("amp;", "");

                    var locationNode = row.Descendants("td").ElementAt(2);
                    var date = row.Descendants("td").ElementAt(3);

                    job.Location = locationNode.InnerText;
                    job.PostedDate = date.InnerText;

                    jobs.Add(job);
                }

                return jobs;
            });
        }

        private string CreateURL()
        {
            var url = this.JobSearchWebServiceURL;

            URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.SORT_FIELD, DiceSortFields.POSTED_DATE);
            URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.SORT_DIRECTION, DiceSortDirection.DESCENDING);
            URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.VIEW_TYPE, DiceViewTypes.SUMMARY);
            URLHelper.ConcatenateURLParameters<int>(ref url, DiceURLConstants.PER_PAGE, this.PerPage);
            URLHelper.ConcatenateURLParameters<int>(ref url, DiceURLConstants.DAYS_BACK, this.DaysBack);
            URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.KEYWORD, Uri.EscapeDataString(this.Keywords));
            URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.LOCATION, this.Location);

            var value = this.Page * this.PerPage;

            URLHelper.ConcatenateURLParameters<int>(ref url, DiceURLConstants.PAGE_NUMBER, value);

            if (this.TelecommutingOnly.HasValue)
            {
                if (this.TelecommutingOnly.Value)
                    URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.TELECOMMUTING, DiceTelecommutingOptions.TELECOMMUTING_ONLY);
                else
                    URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.TELECOMMUTING, DiceTelecommutingOptions.NO_TELECOMMUTING);
            }
            else
            {
                // return all
                URLHelper.ConcatenateURLParameters<string>(ref url, DiceURLConstants.TELECOMMUTING, DiceTelecommutingOptions.ALL);
            }

            return url;
        }
    }
}
