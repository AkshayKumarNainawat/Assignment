using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment
{
    public class ActiveCompaignServices: IActiveCompaignsServices
    {
        /// <summary>
        /// fetch compaigns records from external api and return acive reocrds based on created and enddate.
        /// </summary>
        public async Task<IEnumerable<Campaigns>> FetchActiveCompaigns()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign");
            IEnumerable<Campaigns> finalRes = new List<Campaigns>();
            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                List<Campaigns> result = JsonConvert.DeserializeObject<List<Campaigns>>(responseValue);
                finalRes = from i in result 
                           where Convert.ToDateTime(i.endDate) >= DateTime.Today && Convert.ToDateTime(i.created) > DateTime.Today.AddDays(-30) 
                           select i;
            }
            return finalRes;
        }
    }
}
