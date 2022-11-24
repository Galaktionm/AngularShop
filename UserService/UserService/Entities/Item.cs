using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Entities
{
    public class Item
    {
        public long id { get; set; }

        public string userId { get; set; }

        public int available { get; set; }

        public Item() { }

        public Item(long id, string userId)
        {
            this.id = id;
            this.userId = userId;
        }
    }
}
