using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/WishList/Update")]
    [ApiController]
    public class WishListUpdateController : ControllerBase
    {
        public IHubContext<WishListHub> hub;

        public WishListUpdateController(IHubContext<WishListHub> hub)
        {
            this.hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            await hub.Clients.All.SendAsync("Update", "Wishlist items available");
            return Ok("Update message sent.");
        }

    }
}
