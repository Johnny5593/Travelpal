using System.Collections.Generic;
using System.Windows;

namespace travelpal
{
    public partial class RegisterWindow : Window
    {
        private TravelManager travelManager;

        public RegisterWindow(TravelManager manager)
        {
            InitializeComponent();
            travelManager = manager;

            // Fyll ComboBox med lista över länder (du behöver skapa denna lista själv)
            List<string> countries = new List<string> { "Sverige", "Norge", "Danmark", "Finland", "Island" };
            CountryComboBox.ItemsSource = countries;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Kontrollera om användarnamnet redan är upptaget
            if (travelManager.IsUsernameTaken(username))
            {
                MessageBox.Show("Användarnamnet är redan upptaget. Vänligen välj ett annat användarnamn.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Skapa en ny användare och lägga till den i TravelManager
                User newUser = new User { Username = username, Password = password };
                travelManager.AddUser(newUser);

                // Visa meddelande och stäng fönstret
                MessageBox.Show("Användaren har skapats framgångsrikt.", "Bekräftelse", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
    }
}
