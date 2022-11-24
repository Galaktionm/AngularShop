using System.Net;
using System.Text.Json;
using System.Web.Http.ModelBinding;
using Gateway.Entities;
using Gateway.Helpers;
using Gateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private AuthenticationService service;
        public BookController(AuthenticationService service)
        {
            this.service = service;
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllBooks()
        {
            var tokenStringValues = Request.Headers.Authorization;
            var authResult = false;
            if (StringValues.IsNullOrEmpty(tokenStringValues)==false){
                authResult = await service.validateTokenAsync(tokenStringValues);
            }
        

            if (authResult==true)
            {
                HttpClient client = new HttpClient();
                var response=await client.GetAsync("http://localhost:8113/api/Books/All");

                var result = await response.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                List<Book> book = JsonConvert.DeserializeObject<List<Book>>(result);

                return Ok(book);
            } else if(authResult==false || StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                return Unauthorized("Please log in to view this page");
            }
            else {
                return BadRequest();
            }
        }

        [HttpGet("Starter")]
        public async Task<IActionResult> getStarterBooks()
        {
            var tokenStringValues = Request.Headers.Authorization;
            var authResult = false;
            if (StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                authResult = await service.validateTokenAsync(tokenStringValues);
            }

            if (authResult == true)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("http://localhost:8113/api/Books/Starter");

                var result = await response.Content.ReadAsStringAsync();
                
                List<Book> items =JsonConvert.DeserializeObject<List<Book>>(result);

                return Ok(items);
            }
            else if (authResult == false || StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                return Unauthorized("Please log in to view this page");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Add/{id}")]
        public async Task<IActionResult> AddBookToUser(Book book, string id)
        {
            var tokenStringValues = Request.Headers.Authorization;
            var authResult = false;
            if (StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                authResult = await service.validateTokenAsync(tokenStringValues);
            }


            if (authResult == true)
            {
                HttpClient client = new HttpClient();
                JsonSerializerOptions options = new JsonSerializerOptions();

                var bookTest = book;

                var response = await client.PostAsJsonAsync("http://localhost:8113/api/Books/Add/"+id, book);

                var suceeded =response.IsSuccessStatusCode;
               
                if(suceeded == true)
                {
                    AddBookResult result = await response.Content.ReadFromJsonAsync<AddBookResult>();
                    
                    if (result.userId != null)
                    {
                        var addResult=await client.PostAsJsonAsync("https://localhost:7019/api/Users/Add/Book", result);

                        if (addResult.IsSuccessStatusCode)
                        {
                            return Ok(new { message = "Book added" });
                        } else
                        {
                            return BadRequest("BR1");
                        }
                        
                    }
                }  
               return BadRequest("BR2");               
            }
            else if (authResult == false || StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                return Unauthorized("Please log in to view this page");
            }
            else
            {
                return BadRequest("BR3");
            }

        }


        [HttpPost("Add/Wishlist")]
        public async Task<IActionResult> postWish(BookWishList wish)
        {
            var tokenStringValues = Request.Headers.Authorization;
            var authResult = false;
            
            if (StringValues.IsNullOrEmpty(tokenStringValues) == false)
            {
                authResult = await service.validateTokenAsync(tokenStringValues);
            }

            if (authResult == true)
            {
                HttpClient client = new HttpClient();
                var url = "http://localhost:8113/api/Books/Add/WishList";

                var test = wish;

                var response = await client.PostAsJsonAsync(url, wish);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }

            }
            else
            {
                return Unauthorized();
            }

            return BadRequest();


        }
    }


    public class AddBookResult
        {
            public long bookId { get; set; }
            public string userId { get; set; }

            public AddBookResult() { }

            public AddBookResult(long bookId, string userId)
            {
                this.bookId=bookId;
                this.userId = userId;
            }
        }

    public class BookWishList : WishList
    {
        public string title { get; set; }

        public string author { get; set; }

        public string genre { get; set; }

        public BookWishList() { }


        public BookWishList(string userId, int lowPrice, int highPrice,
            string title, string author, string genre) : base(userId, lowPrice, highPrice)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
        }
    }

    
}
