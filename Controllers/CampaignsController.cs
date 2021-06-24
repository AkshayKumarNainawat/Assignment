using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private ICampaignServices services;
        public CampaignsController(ICampaignServices services)
        {
            this.services = services;
        }
        [HttpGet]
        public async Task<IEnumerable<object>> GetCompaignsRecords()
        {
            return await services.FetchCampaignsList();
        }
    }
}
