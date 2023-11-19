using System.Collections.Generic;

namespace travelpal
{
    public class User
    {
        public string Username { get; set; } = string.Empty; // Assign a default non-null value
        public string Password { get; set; } = string.Empty; // Assign a default non-null value
        public List<Travel> Travels { get; set; } = new List<Travel>();
        public bool IsNewlyRegistered { get; set; } = false; // Default value is false

        // Tom konstruktor by default
        public User()
        {
        }

        // Konstruktor med parametrar
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