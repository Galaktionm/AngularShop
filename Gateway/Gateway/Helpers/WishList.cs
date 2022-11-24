using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Helpers
{
    
    public class WishList 
    {
        public String userId { get; set; }

        public int lowPrice { get; set; }

        public int highPrice { get; set; }

        public WishList() { }

        public WishList(string userId, int lowPrice, int highPrice)
        {
            this.userId = userId;
            this.lowPrice = lowPrice;
            this.highPrice = highPrice;
        }

    }
}
