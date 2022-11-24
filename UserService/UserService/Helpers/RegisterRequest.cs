namespace UserService.Helpers
{
    public class RegisterRequest
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public RegisterRequest() { }

        public RegisterRequest(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

    }
}
