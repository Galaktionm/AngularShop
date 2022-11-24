namespace Gateway.Helpers
{
    public class UserRequest
    {
        public string userId { get; set; }

        public UserRequest(string userId)
        {
            this.userId = userId;
        }
    }
}
