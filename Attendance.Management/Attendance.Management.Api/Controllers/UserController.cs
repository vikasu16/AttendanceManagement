using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Attendance.Management.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GeUser")]
        public IActionResult GetUser()
        {
            return Ok("First Testing API");
        }
    }
}
