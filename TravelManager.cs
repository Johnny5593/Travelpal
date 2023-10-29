using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace travelpal
{
    public class TravelManager
    {
        private List<User> Users = new List<User>();
        private List<Travel> Travels = new List<Travel>();

        public bool RegisterUser(string username, string password)
        {
            if (Users.Any(u => u.Username == username))
            {
                // User with the same username already exists
                return false;
            }

            User newUser = new User(username, password);
            Users.Add(newUser);
            return true;
        }

        public void AddUser(User user)
        {
            Console.WriteLine("User in TravelManager", user);
            Users.Add(user);
        }

        public bool IsUsernameTaken(string username)
        {
            return Users.Any(u => u.Username == username);
        }

        public User ValidateUser(string username, string password)
        {
            User? user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }

        public void AddTravel(Travel travel)
        {
            Console.WriteLine("Travel in TravelManager", travel);
            Travels.Add(travel);
        }
    }
}