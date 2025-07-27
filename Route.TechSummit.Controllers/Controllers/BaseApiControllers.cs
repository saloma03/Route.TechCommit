using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Route.TechSummit.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        // Common functionality for all controllers
        protected IActionResult HandleResult<T>(T result)
        {
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
