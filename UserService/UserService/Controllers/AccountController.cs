using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/Account")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> manager;

        public AccountController(UserManager<User> manager)
        {
             this.manager = manager;
        }

        
        [HttpGet("{userId}")]
        public async Task<IActionResult> getUserAccount(string userId)
        {
            var user=await manager.FindByIdAsync(userId);

            if (user != null)
            {
                return Ok(new { email = user.Email, username=user.UserName });
            } 

            return Unauthorized();

        }




    }
}
