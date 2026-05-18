using Microsoft.AspNetCore.Mvc;

namespace JobsModule.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated =true)]
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiVersion}/app")]
    public class App1Controller : ControllerBase
    {
        [HttpGet]
        [ApiVersion("1.0", Deprecated =true)]
        [Obsolete("This version of Get is obsolete, please use the higher versions available.")]
        public IActionResult GetAppsV1()
        {
            Response.Headers.Add("Sunset", "Wed, 31 Dec 2026 23:59:59 GMT");
            Response.Headers.Add("Warning", "299 - API v1 is deprecated and will be removed on 2026-12-31.");
            Response.Headers.Add("Link", "<https://yourapi.com/docs/v1-deprecation>; rel=\"deprecation\"");
            return  Ok("Invoked GetApps for version 1");
        }

        [HttpGet]
        [ApiVersion("2.0")]
        public IActionResult GetAppsV2()
        {
            return Ok("Invoked GetApps for version 2");
        }
    }
}
