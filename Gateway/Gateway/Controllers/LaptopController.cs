using System.Net;
using System.Text.Json;
using System.Web.Http.ModelBinding;
using Gateway.Entities;
using Gateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    [Route("api/laptops")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private AuthenticationService service;
        public LaptopController(AuthenticationService service)
        {
            this.service = service;
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllLaptops()
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
                var response = await client.GetAsync("http://localhost:8113/api/Laptops/All");

                var result = await response.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                List<Laptop> laptop = JsonConvert.DeserializeObject<List<Laptop>>(result);

                return Ok(laptop);
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

        [HttpGet("Starter")]
        public async Task<IActionResult> getStarterLaptops()
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
                var response = await client.GetAsync("http://localhost:8113/api/Laptops/Starter");

                var result = await response.Content.ReadAsStringAsync();

                List<Laptop> items = JsonConvert.DeserializeObject<List<Laptop>>(result);

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
        public async Task<IActionResult> AddlaptopToUser(Laptop laptop, string id)
        {
            var tokenStringValues = Request.Headers.Authorization;
            var authResult = await service.validateTokenAsync(tokenStringValues);


            if (StringValues.IsNullOrEmpty(tokenStringValues) == false && authResult == true)
            {
                HttpClient client = new HttpClient();
                JsonSerializerOptions options = new JsonSerializerOptions();

                var response = await client.PostAsJsonAsync("http://localhost:8113/api/Items/Add/Laptops/" + id, laptop);

                var suceeded = response.IsSuccessStatusCode;

                if (suceeded == true)
                {
                    AddLaptopResult result = await response.Content.ReadFromJsonAsync<AddLaptopResult>();

                    if (result.userId != null)
                    {
                        var addResult = await client.PostAsJsonAsync("https://localhost:7019/api/Users/AddItem", result);

                        if (addResult.IsSuccessStatusCode)
                        {
                            return Ok();
                        }
                        else
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

        public class AddLaptopResult
        {
            public long itemId { get; set; }
            public string userId { get; set; }

            public AddLaptopResult() { }

            public AddLaptopResult(long ItemId, string userId)
            {
                this.itemId = ItemId;
                this.userId = userId;
            }
        }

    }
}