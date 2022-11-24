using UserService;

namespace UserService.Entities
{
    public class Book : Item
    {
        public Book() : base() { }

        public Book(long id, string userId) : base(id, userId)
        {
           
        }



    }
}
