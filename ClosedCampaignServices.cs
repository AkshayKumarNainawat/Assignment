using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment
{
    public class ClosedCampaignServices: IClosedCampaignServices
    {
        /// <summary>
        /// fetch compaigns records from external api and return closed result based on enddate or procuredAmount filter.
        /// </summary>
        public async Task<IEnumerable<Campaigns>> FetchClosedCampaigns()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign");
            IEnumerable<Campaigns> finalResult = new List<Campaigns>();
            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                List<Campaigns> result = JsonConvert.DeserializeObject<List<Campaigns>>(responseValue);
                finalResult = from i in result
                              where Convert.ToDateTime(i.endDate) < DateTime.Today || i.procuredAmount >= i.totalAmount
                              select i;
            }
            return finalResult;
        }
    }
}
