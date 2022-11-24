using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/Test")]
    [ApiController]
    [Authorize(Roles="User")]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public String getMessage()
        {
            return "Koko sayvarelia";
        }

    }
}
