namespace Gateway.Entities
{
    public class Book : Item
    {
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public Book() : base() { }

        public Book(long id, int price, int available, string title, string author, string genre) : base(id, price, available)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
        }

        public enum Genre
        {
            Horror, Romance, Educational
        }



    }
}
