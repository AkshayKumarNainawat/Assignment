﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    public interface IClosedCampaignServices
    {
        Task<IEnumerable<Campaigns>> FetchClosedCampaigns();
    }
}
