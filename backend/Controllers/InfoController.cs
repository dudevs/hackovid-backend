using System;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Info> Get()
        {
            Info info = new Info
            {
                version = "v1",
                databaseConnectionEstablished = false,
                time = DateTime.Now
            };

            return Ok(info);
        }
    }
}
