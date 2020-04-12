using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /**
     * Supermarket controller
     * Performs all the requests made by the frontend
     */
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketController : ControllerBase
    {
        private ISupermarketProvider _supermarketProvider;

        public SupermarketController(ISupermarketProvider supermarketProvider)
        {
            _supermarketProvider = supermarketProvider;
        }


        /**
         * Returns all the supermarkets given an address
         */
        [Route("byaddress/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket>>> GetSupermarketsByAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                return BadRequest();

            IEnumerable<Supermarket> supermarketList = await _supermarketProvider.FetchSupermarketsByAddress(address);

            return Ok(supermarketList);
        }

        /**
         * Returns all the supermarkets given a geolocation
         */
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

        /**
         * Returns the supermarket basic goods info with their timeline
         */
        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<SupermarketData>> GetSupermarketData(string id)
        {
            IEnumerable<SupermarketData> spermarketDataList = _supermarketProvider.GetSupermarketDataById(id);

            return Ok(spermarketDataList);
        }

        /**
         * Allows to vote given a supermarket id if there is stock or not for a basic good
         */
        [Route("{id}/basicgood/{basicgood}")]
        [HttpPost]
        public ActionResult<SupermarketData> VoteBasicGood(string id, string basicgood, bool status)
        {
            bool isVoteRegistered = _supermarketProvider.VoteBasicGood(id, basicgood, status);

            VoteRegistered voteRegistered = new VoteRegistered()
            {
                id = id,
                basicGood = basicgood,
                status = status,
                voteRegistered = isVoteRegistered
            };


            return Ok(voteRegistered);
        }
    }
}
