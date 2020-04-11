using System;
using backend.Models;
using backend.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private ISupermarketProvider _supermarketProvider;

        public InfoController(ISupermarketProvider supermarketProvider)
        {
            _supermarketProvider = supermarketProvider;
        }


        [HttpGet]
        public ActionResult<Info> Get()
        {
            Info info = new Info
            {
                version = "v1",
                databaseConnectionEstablished = _supermarketProvider.CheckDatabaseConnection(),
                time = DateTime.Now
            };

            return Ok(info);
        }
    }
}
