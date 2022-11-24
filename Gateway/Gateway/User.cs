using Gateway.Entities;
using Microsoft.AspNetCore.Identity;

namespace Gateway
{
    public class User
    {
        public string userId { get; set; }

        public List<Item> Books = new List<Item>();
    }
}
