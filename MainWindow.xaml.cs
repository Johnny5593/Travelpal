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

            // Skapa standardanvändare och lägg till resor
            User defaultUser = new User("user", "password");
            User defaultAdmin = new User("admin", "password");
            defaultUser.AddTravel(new Travel { City = "Stockholm", Country = "Sverige" });
            defaultUser.AddTravel(new Travel { City = "Berlin", Country = "Tyskland" });
            defaultAdmin.AddTravel(new Travel { City = "Agadir", Country = "Morroco" });
            defaultAdmin.AddTravel(new Travel { City = "Köpenhamn", Country = "Danmark" });
            travelManager.RegisterUser(defaultUser);
            travelManager.RegisterUser(defaultAdmin);


        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            User user = travelManager.ValidateUser(username, password);
            if (user != null)
            {
                // Pass the existing travelManager instance to TravelsWindow
                TravelsWindow travelsWindow = new TravelsWindow(user, travelManager);
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
