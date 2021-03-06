using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosedCampaignsController : ControllerBase
    {
        private IClosedCampaignServices services;
        public ClosedCampaignsController(IClosedCampaignServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<Campaigns>> GetClosedCampaigns()
        {
            return await services.FetchClosedCampaigns();
        }
    }
}
