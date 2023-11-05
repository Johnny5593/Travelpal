using System.Collections.Generic;

namespace travelpal
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Travel> Travels { get; set; } = new List<Travel>();

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

        // Metod för att lägga till en resa för användaren
        public void AddTravel(Travel travel)
        {
            Travels.Add(travel);
        }
    }
}
