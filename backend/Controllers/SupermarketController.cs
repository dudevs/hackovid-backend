using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
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

        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<SupermarketData>> GetSupermarketData(string id)
        {
            IEnumerable<SupermarketData> spermarketDataList = _supermarketProvider.GetSupermarketDataById(id);

            return Ok(spermarketDataList);
        }

        [Route("{id}/basicgood/{basicgood}")]
        [HttpPost]
        public ActionResult<SupermarketData> VoteBasicGood(string id, string basicgood, bool status)
        {
            bool voteRegistered = _supermarketProvider.VoteBasicGood(id, basicgood, status);

            if (voteRegistered)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
