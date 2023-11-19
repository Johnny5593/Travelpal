// TravelsWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.Windows;

namespace travelpal
{
    public partial class TravelsWindow : Window
    {
        private User loggedInUser;
        private TravelManager travelManager;

        public TravelsWindow(User user, TravelManager manager, List<Travel> travels)
        {
            InitializeComponent();
            loggedInUser = user;
            travelManager = manager;
            loggedInUser.Travels = travels; // Update the user's travels

            // Display logged-in user's username
            UsernameLabel.Text = $"Inloggad som: {loggedInUser.Username}";

            // Fill the list with existing travels

            UpdateTravelList();
        }


        public void UpdateTravelList()
        {
            // Get the travels for the logged-in user and fill the list
            TravelList.ItemsSource = loggedInUser.Travels;
        }

        private void AddTravelButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddTravelWindow with the current travelManager instance and the logged-in user
            AddTravelWindow addTravelWindow = new AddTravelWindow(travelManager, loggedInUser);
            addTravelWindow.ShowDialog();

            // Update the list after the user has added a travel
            UpdateTravelList();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected travel from the list
            var selectedTravel = TravelList.SelectedItem as Travel;

            if (selectedTravel != null)
            {
                // Open the detail window for the selected travel
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel);
                travelDetailsWindow.ShowDialog();
            }
            else
            {
                // Show a warning if no travel is selected
                MessageBox.Show("Vänligen markera en resa för att se detaljer.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected travel from the list
            var selectedTravel = TravelList.SelectedItem as Travel;

            if (selectedTravel != null)
            {
                // Remove the selected travel
                bool removed = travelManager.RemoveTravel(selectedTravel, loggedInUser.Username);

                if (removed)
                {
                    // Update the list after the travel has been removed
                    UpdateTravelList();
                }
                else
                {
                    MessageBox.Show("Fel: Resan kunde inte tas bort.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Show a warning if no travel is selected
                MessageBox.Show("Vänligen markera en resa för att ta bort den.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window and open the main window again
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Pass the travelManager instance to UserDetailsWindow
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(loggedInUser, travelManager);
            userDetailsWindow.ShowDialog();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            // Open an info window for the application and TravelPal company
            Console.WriteLine("INFO!");
        }
    }
}