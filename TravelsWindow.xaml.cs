using System;
using System.Windows;

namespace travelpal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private User loggedInUser;
        private TravelManager travelManager;

        public TravelsWindow(User user, TravelManager manager)
        {
            InitializeComponent();
            loggedInUser = user;
            travelManager = manager;

            // Visa inloggade användarens användarnamn
            UsernameLabel.Text = $"Inloggad som: {loggedInUser.Username}";

            // Fyll listan med befintliga resor
            UpdateTravelList();
        }

        private void UpdateTravelList()
        {
            // Hämta resor från TravelManager och fyll listan
            TravelList.ItemsSource = travelManager.GetTravels(); // Antag att GetTravels returnerar en lista av Travel-objekt
        }

        private void AddTravelButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddTravelWindow with the current travelManager instance
            AddTravelWindow addTravelWindow = new AddTravelWindow(travelManager);
            addTravelWindow.ShowDialog();

            // Update the list after the user has added a travel
            UpdateTravelList();
        }


        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Hämta den markerade resan från listan
            Travel selectedTravel = TravelList.SelectedItem as Travel;

            if (selectedTravel != null)
            {
                // Öppna detaljfönstret för den markerade resan
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel);
                travelDetailsWindow.ShowDialog();
            }
            else
            {
                // Visa varningsruta om ingen resa är markerad
                MessageBox.Show("Vänligen markera en resa för att se detaljer.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Hämta den markerade resan från listan
            Travel selectedTravel = TravelList.SelectedItem as Travel;

            if (selectedTravel != null)
            {
                // Ta bort den markerade resan
                travelManager.RemoveTravel(selectedTravel);

                // Uppdatera listan efter att resan har tagits bort
                UpdateTravelList();
            }
            else
            {
                // Visa varningsruta om ingen resa är markerad
                MessageBox.Show("Vänligen markera en resa för att ta bort den.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Stäng det nuvarande fönstret och öppna huvudfönstret igen
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Pass the travelManager instance to UserDetailsWindow
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(loggedInUser, travelManager);
            userDetailsWindow.ShowDialog();
            Console.WriteLine("USERBTN CLICK!");
        }


        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            // Öppna ett infofönster för applikationen och TravelPal-företaget
            //InfoWindow infoWindow = new InfoWindow();
            //infoWindow.ShowDialog();
            Console.WriteLine("INFO!");
        }
    }

}
