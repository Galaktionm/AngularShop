using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Helpers;

namespace UserService.Controllers
{
    [Route("api/Users/Add")]
    [ApiController]
    public class AddToUserController : ControllerBase
    {
        private readonly UserManager<User> manager;
        private readonly DatabaseContext databaseContext;


        public AddToUserController(UserManager<User> manager, DatabaseContext databaseContext)
        {
            this.manager = manager;
            this.databaseContext = databaseContext;
        }

        [HttpPost("Book")]
        public async Task<IActionResult> AddBookToUserAsync(AddBookResult result)
        {
            var user = await manager.FindByIdAsync(result.userId);
   
            if (user != null)
            {
                Book book = new Book(result.bookId, result.userId);
                user.Items.Add(book);
                databaseContext.Add(book);
                await databaseContext.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
            
        }
    }
}
