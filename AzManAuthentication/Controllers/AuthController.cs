using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AzManAuthentication.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiController
    {
        [HttpGet]
        [Route("hola")]
        public IHttpActionResult Index()
        {
            return Ok("Hola");
        }
    }
}