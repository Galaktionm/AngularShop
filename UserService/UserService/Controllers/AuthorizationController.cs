using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Helpers;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/Authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext context;
        private readonly UserManager<User> userManager;
        private readonly JwtHandler jwtHandler;

        public AuthorizationController(
            DatabaseContext context,
            UserManager<User> userManager,
            JwtHandler jwtHandler)
        {
            this.context = context;
            this.userManager = userManager;
            this.jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null
                || !await userManager.CheckPasswordAsync(user, loginRequest.Password))
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password."
                });
            var secToken = await jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Login successful",
                Token = jwt,
                Id = user.Id
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (await userManager.FindByEmailAsync(registerRequest.email) != null)
            {
                return Forbid();
            }

            var user = new User();
            user.UserName = registerRequest.username;
            user.Email=registerRequest.email;
            var register = await userManager.CreateAsync(user, registerRequest.password);

            if (register.Succeeded)
            {
                return Ok(new { message = "User registered" });
            }

            return BadRequest();       
        }

    }
}
