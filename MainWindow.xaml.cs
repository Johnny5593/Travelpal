using System.Windows;
using System.Windows.Controls;

namespace travelpal
{
    public partial class MainWindow : Window
    {
        private TravelManager travelManager;

        public MainWindow()
        {
            InitializeComponent();
            travelManager = new TravelManager();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            User user = travelManager.ValidateUser(username, password);
            if (user != null)
            {
                TravelsWindow travelsWindow = new TravelsWindow(user);
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

            bool registrationSuccess = travelManager.RegisterUser(username, password);
            if (registrationSuccess)
            {
                ErrorMessage.Text = "Användare registrerad framgångsrikt.";
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

