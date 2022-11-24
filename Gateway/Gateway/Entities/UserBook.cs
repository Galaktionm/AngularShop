namespace Gateway.Entities
{
    public class UserBook
    {
        public long bookId { get; set; }

        public UserBook(long bookId)
        {
            this.bookId = bookId;
        }
    }
}
