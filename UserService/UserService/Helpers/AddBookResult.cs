using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Helpers
{
    public class AddBookResult
    {
        public long bookId { get; set; }
        public string userId { get; set; }

        public AddBookResult() { }

        public AddBookResult(long ItemId, string userId)
        {
            this.bookId = ItemId;
            this.userId = userId;
        }
    }
}
