using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Principal;
using Microsoft.Interop.Security.AzRoles;
using System.Configuration;
using AzManAuthApi.Services;
using System.Runtime.InteropServices;

namespace AzManAuthApi.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiController
    {
        private string Path;

        public AuthController()
        {
            Path = ConfigurationManager.AppSettings["AzManPath"];
        }

        [HttpGet]
        [Route("azauth")]
        public IHttpActionResult AzAuth(string applicationName)
        {
            AzAuthService azAuthService = new AzAuthService(Path, applicationName);
            string username = null;
            try
            {

                bool accessGranted = azAuthService.checkAccess("Audi", 1, out username);
                Dictionary<String, Object> mensaje = new Dictionary<string, object>();
                mensaje.Add("access", accessGranted);
                mensaje.Add("username", username);
                return Ok(mensaje);
            }
            catch (COMException)
            {
                return BadRequest("No se encontró la aplicación");
            }
            
        }
    }
}
