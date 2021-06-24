using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment
{
    public class CampaignServices: ICampaignServices
    {
        /// <summary>
        /// fetch compaigns records from external api and return result in descending order with specific fields.
        /// </summary>
        public async Task<IEnumerable<object>> FetchCampaignsList()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign");
            List<object> finalRes = new List<object>();
            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                List<Campaigns> result = JsonConvert.DeserializeObject<List<Campaigns>>(responseValue);
                var res = from i in result orderby i.totalAmount descending select i;
                foreach (var item in res)
                {
                    finalRes.Add(new
                    {
                        title = item.title,
                        totalAmount = item.totalAmount,
                        backersCount = item.backersCount,
                        endDate = item.endDate
                    });
                }
            }
            return finalRes;
        }
    }
}
