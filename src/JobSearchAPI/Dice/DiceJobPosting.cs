using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

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

        private WebClient client = null;

        public Task<DiceJobDetail> GetJobDetailAsync()
        {
            return Task.Factory.StartNew<DiceJobDetail>(() =>
            {
                DiceJobDetail detail = new DiceJobDetail();

                if (client == null)
                    client = new WebClient();

                var htmlData = client.DownloadString(this.JobURL);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlData);

                try
                {
                    CheckForError(doc);
                }
                catch (Exception ex)
                {
                    detail.Description = ex.Message;
                    return detail;
                }

                var detailRows = (from c in doc.DocumentNode.SelectNodes("//div[@class='pane']")
                                  select c).ToList();

                foreach (var d in detailRows)
                {
                    var info = (from c in d.SelectNodes("//dd")
                                select c).ToList();
                }

                return detail;
            });
        }

        private void CheckForError(HtmlDocument htmlData)
        {
            var error = htmlData.DocumentNode.SelectNodes("//div[@class='error']");

            if (error != null)
            {
                throw new Exception(error[0].InnerText);
            }
        }
    }
}
