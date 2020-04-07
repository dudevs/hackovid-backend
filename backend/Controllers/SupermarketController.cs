using System;
using System.Collections.Generic;
using backend.Models;
using backend.Models.Filters;
using backend.Providers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Supermarket>> Get()
        {
            SupermarketFilter filter = new SupermarketFilter();
            List<Supermarket> supermarketList = SupermarketProvider.FetchSupermarkets(filter);

            return Ok(supermarketList);
        }
    }
}
