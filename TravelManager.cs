using System;
using System.Collections.Generic;
using System.Linq;

namespace travelpal
{
    public class TravelManager
    {
        private List<User> Users = new List<User>();
        private List<Travel> Travels = new List<Travel>();

        public TravelManager()
        {
            InitializeDefaultUsers();
        }

        private void InitializeDefaultUsers()
        {
            User defaultUser = new User("user", "password");
            User defaultAdmin = new User("admin", "password");

            defaultUser.AddTravel(new Travel { City = "Stockholm", Country = "Sverige" });
            defaultUser.AddTravel(new Travel { City = "Berlin", Country = "Tyskland" });

            defaultAdmin.AddTravel(new Travel { City = "Malmö", Country = "Sverige" });
            defaultAdmin.AddTravel(new Travel { City = "Köpenhamn", Country = "Danmark" });

            AddDefaultTravels(defaultUser, false);
            AddDefaultTravels(defaultAdmin, true);
        }



        public bool RegisterUser(User user)
        {
            if (Users.Any(u => u.Username == user.Username))
            {
                return false;
            }

            // Add the user to the list of users
            Users.Add(user);

            // Add only the new user's travels to the global list of travels
            Travels.AddRange(user.Travels);

            return true;
        }

        private void AddDefaultTravels(User user, bool isAdmin)
        {
            if (isAdmin)
            {
                user.AddTravel(new Travel { City = "Malmö", Country = "Sweden" });
                user.AddTravel(new Travel { City = "Köpenhamn", Country = "Danmark" });
            }
            else
            {
                user.AddTravel(new Travel { City = "Stockholm", Country = "Sverige" });
                user.AddTravel(new Travel { City = "Berlin", Country = "Tyskland" });
            }
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

        public User? ValidateUser(string username, string password)
        {
            User? user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }

        public void AddTravel(Travel travel, string username)
        {
            // Find the user with the specified username
            User? user = Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                // Add the travel to the user's travels
                user.AddTravel(travel);

                // Add the travel to the global list of travels in TravelManager
                Travels.Add(travel);
            }
            else
            {
                Console.WriteLine($"User with username {username} not found.");
            }
        }


        public bool RemoveTravel(Travel travel, string username)
        {
            // Find the user with the specified username
            User user = Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                // Remove the travel from the user's travels
                user.Travels.Remove(travel);

                // Remove the travel from the global list of travels in TravelManager
                Travels.Remove(travel);

                return true;
            }

            return false;
        }


        public List<Travel> GetTravels(string username)
        {
            // Find the user with the specified username
            User user = Users.FirstOrDefault(u => u.Username == username);

            // If user is found, return only their travels; otherwise, return an empty list
            return user?.Travels ?? new List<Travel>();
        }


        public List<Travel> GetTravelsUser(string username)
        {
            // Find the user with the specified username
            User? user = Users.FirstOrDefault(u => u.Username == username);

            // If user is found, return only their travels; otherwise, return an empty list
            return user?.Travels ?? new List<Travel>();
        }

    }
}