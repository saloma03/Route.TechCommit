using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Route.TechSummit.Controllers.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        // Common functionality for all controllers
        protected IActionResult HandleResult<T>(object value, T result)
        {
            if (result == null) return NotFound();
            return Ok(result);
        }

        public IActionResult HandleResult<T>(T result, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (result == null)
            {
                return StatusCode((int)statusCode, "No data found.");
            }

            return StatusCode((int)statusCode, result);
        }

    }
}
