using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    public interface ICampaignServices
    {
        Task<IEnumerable<object>> FetchCampaignsList();
    }
}
