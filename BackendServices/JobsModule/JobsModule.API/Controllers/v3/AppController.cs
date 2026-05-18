using Microsoft.AspNetCore.Mvc;

namespace JobsModule.API.Controllers.v3
{
    [ApiController]
    [ApiVersion("3.0")]
    [Route("/api/v{version:apiVersion}/app")]
    public class AppController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAppV3()
        {
            return Ok("Invoked for version 3 of Get Apps");
        }
    }
}
