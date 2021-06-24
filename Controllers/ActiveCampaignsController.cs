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
    public class ActiveCampaignsController : ControllerBase
    {
        private IActiveCompaignsServices service;
        public ActiveCampaignsController(IActiveCompaignsServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Campaigns>> ActiveCompaigns()
        {
            return await service.FetchActiveCompaigns();
        }
    }
}
