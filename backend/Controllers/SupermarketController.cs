using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Providers;
using backend.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketController : ControllerBase
    {
        private ISupermarketProvider _supermarketProvider;

        public SupermarketController(ISupermarketProvider supermarketProvider)
        {
            _supermarketProvider = supermarketProvider;
        }
        /*[HttpGet]
        public ActionResult<List<Supermarket>> Get()
        {
            //SupermarketFilter filter = new SupermarketFilter();
            List<Supermarket> supermarketList = SupermarketProvider.FetchSupermarkets(filter);

            return Ok(supermarketList);
        }*/

        [Route("byaddress/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket>>> GetSupermarketsByAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                return BadRequest();

            IEnumerable<Supermarket> supermarketList = await _supermarketProvider.FetchSupermarketsByAddress(address);

            return Ok(supermarketList);
        }

        [Route("bylocation/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket>>> GetSupermarketsLocation(double lat, double lon)
        {
            GeoCoordinate geoCoodinate = new GeoCoordinate(lat, lon);
            if (!geoCoodinate.IsValid())
                return BadRequest();

            IEnumerable<Supermarket> supermarketList = await _supermarketProvider.FetchSupermarketsByLocation(geoCoodinate);

            return Ok(supermarketList);
        }
    }
}
