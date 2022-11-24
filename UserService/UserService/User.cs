using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using UserService.Entities;

namespace UserService
{
    public class User : IdentityUser
    {

        public List<Item> Items { get; set; }= new List<Item>();
      
        public User() { }

        public User(String username, String email)
        {
            this.UserName = username;
            this.Email = email;
        }

    }
}
