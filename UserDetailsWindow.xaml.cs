using System.Windows;

namespace travelpal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private TravelManager travelManager;

        public UserDetailsWindow(User loggedInUser, TravelManager travelManager)
        {
            LoggedInUser = loggedInUser;
            TravelManager = travelManager;
        }

        public User LoggedInUser { get; }
        public TravelManager TravelManager { get; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = UsernameTextBox.Text;
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string newCountry = CountryComboBox.SelectedItem?.ToString();

            // Check if passwords match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Lösenorden matchar inte. Vänligen försök igen.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if the password is valid (at least 6 characters)
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Lösenordet måste vara minst 6 tecken långt.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if the username is available (assuming travelManager is an instance of TravelManager)
            if (travelManager.IsUsernameTaken(newUsername))
            {
                MessageBox.Show("Användarnamnet är redan upptaget. Vänligen välj ett annat användarnamn.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close UserDetailsWindow without saving changes
            Close();
        }

        private void UsernameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Add any specific logic you want to perform when the username text changes
        }

        private void CountryComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
