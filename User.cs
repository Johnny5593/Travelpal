namespace travelpal
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // Default constructor
        public User()
        {
        }

        // Constructor with parameters
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}