using System.Collections.Generic;
using System.Windows;

namespace travelpal
{
    public partial class MainWindow : Window
    {
        private TravelManager travelManager;

        public MainWindow()
        {
            InitializeComponent();
            travelManager = new TravelManager();

            // Create standard users and add default travels
            User defaultUser = new User("user", "password");
            User defaultAdmin = new User("admin", "password");

            // Add default travels based on user type
            AddDefaultTravels(defaultUser, false); // User
            AddDefaultTravels(defaultAdmin, true);  // Admin

            // Register users
            travelManager.RegisterUser(defaultUser);
            travelManager.RegisterUser(defaultAdmin);
        }

        private void AddDefaultTravels(User user, bool isAdmin)
        {
            if (isAdmin)
            {
                user.AddTravel(new Travel { City = "Malmö", Country = "Sverige" });
                user.AddTravel(new Travel { City = "Köpenhamn", Country = "Danmark" });
            }
            else
            {
                user.AddTravel(new Travel { City = "Stockholm", Country = "Sverige" });
                user.AddTravel(new Travel { City = "Berlin", Country = "Tyskland" });
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            User? user = travelManager.ValidateUser(username, password);
            if (user != null)
            {
                List<Travel> travels;

                // Check if the logged-in user is "user" or "admin"
                if (username == "user" || username == "admin")
                {
                    // Check if the user is newly registered
                    if (user.IsNewlyRegistered)
                    {
                        // If newly registered, return an empty list
                        travels = new List<Travel>();
                    }
                    else
                    {
                        // Call GetTravels for "user" or "admin"
                        travels = travelManager.GetTravels(username);
                    }
                }
                else
                {
                    // Call GetTravels for other users
                    travels = new(travelManager.GetTravels(username));
                    travels.Clear();
                }


                // Pass the existing travelManager instance and the travels list to TravelsWindow
                TravelsWindow travelsWindow = new TravelsWindow(user, travelManager, travels);
                travelsWindow.Show();
                Close();
            }

            else
            {
                ErrorMessage.Text = "Fel användarnamn eller lösenord. Försök igen.";
            }
        }



        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage.Text = "Användarnamn och lösenord får inte vara tomma.";
                return;
            }

            User newUser = new User(username, password);
            bool registrationSuccess = travelManager.RegisterUser(newUser);

            if (registrationSuccess)
            {
                SuccessMessage.Text = "Användare registrerad framgångsrikt.";
            }
            else
            {
                ErrorMessage.Text = "Användarnamnet är redan taget. Välj ett annat användarnamn.";
            }
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Användarnamn")
            {
                UsernameTextBox.Text = "";
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Användarnamn";
            }
        }

        private void UsernameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}