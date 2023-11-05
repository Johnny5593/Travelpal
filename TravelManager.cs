using System;
using System.Collections.Generic;
using System.Linq;

namespace travelpal
{
    public class TravelManager
    {
        private List<User> Users = new List<User>();
        private List<Travel> Travels = new List<Travel>();

        public bool RegisterUser(User user)
        {
            if (Users.Any(u => u.Username == user.Username))
            {
                return false;
            }

            Users.Add(user);
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

        public List<Travel> GetTravels()
        {
            return Travels;
        }


        public void AddTravel(Travel travel)
        {
            Console.WriteLine("Travel in TravelManager", travel);
            Travels.Add(travel);
        }

        public bool RemoveTravel(Travel travel)
        {
            bool removed = Travels.Remove(travel);
            return removed;
        }
    }
}
