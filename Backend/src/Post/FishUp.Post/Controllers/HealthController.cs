using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Post.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [Route("check")]
        [HttpGet]
        public IActionResult Check()
            => Ok();
        
        [Authorize]
        [Route("checkJwt")]
        [HttpGet]
        public IActionResult CheckJwt()
            => Ok();
    }
}