using System;
using backend.Models;
using backend.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /**
     * Info controller
     * Checks the backend is up and running
     */
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private ISupermarketProvider _supermarketProvider;

        public InfoController(ISupermarketProvider supermarketProvider)
        {
            _supermarketProvider = supermarketProvider;
        }


        /**
         * returns the be service version and if there is connectivity with the database at the request time
         */
        [HttpGet]
        public ActionResult<Info> Get()
        {
            Info info = new Info
            {
                version = Constants.Constants.VERSION,
                databaseConnectionEstablished = _supermarketProvider.CheckDatabaseConnection(),
                time = DateTime.Now
            };

            return Ok(info);
        }
    }
}
