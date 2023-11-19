using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace travelpal
{
    public partial class AddTravelWindow : Window
    {
        private TravelManager travelManager;
        private User loggedInUser;
        private TravelsWindow travelsWindow;

        public AddTravelWindow(TravelManager manager, User user)
        {
            InitializeComponent();
            travelManager = manager;
            loggedInUser = user;
            this.travelsWindow = travelsWindow;

            List<string> countries = new List<string>
            {
                "Italien", "Danmark", "Skottland", "Frankrike", "Sverige", "Spanien"
            };

            CountryComboBox.ItemsSource = countries;
        }

        private void CityTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CityTextBox.Text == "City")
            {
                CityTextBox.Text = "";
                CityTextBox.Foreground = Brushes.Black;
            }
        }

        private void CityTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                CityTextBox.Text = "City";
                CityTextBox.Foreground = Brushes.Gray;
            }
        }

        private void WorkTripCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MeetingDetailsTextBox.Visibility = Visibility.Visible;
        }

        private void WorkTripCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MeetingDetailsTextBox.Visibility = Visibility.Collapsed;
        }

        // In AddTravelWindow
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input and save the travel details
            if (CountryComboBox.SelectedItem != null)
            {
                Travel newTravel = new Travel
                {
                    City = CityTextBox.Text,
                    Country = CountryComboBox.SelectedItem.ToString(),
                    Travelers = int.Parse(TravelersTextBox.Text),
                    IsWorkTrip = WorkTripCheckBox.IsChecked.GetValueOrDefault(),
                    AllInclusive = AllInclusiveCheckBox.IsChecked.GetValueOrDefault(),
                    MeetingDetails = MeetingDetailsTextBox.Text,
                };

                // Add the new travel to the loggedInUser's travels
                loggedInUser.AddTravel(newTravel);



                // Pass the updated travels list to TravelsWindow
                if (loggedInUser.Username == "user")
                {
                    var res = new TravelsWindow(loggedInUser, travelManager, travelManager.GetTravelsUser("user"));
                    res.Show();

                    Close();
                }
                else if (loggedInUser.Username == "admin")
                {
                    var res = new TravelsWindow(loggedInUser, travelManager, travelManager.GetTravelsUser("admin"));
                    res.Show();

                    Close();
                }
                else if (loggedInUser.Username != "admin")
                {
                    var res = new TravelsWindow(loggedInUser, travelManager, travelManager.GetTravels(loggedInUser.Username));
                    res.Show();

                    Close();
                }
                else if (loggedInUser.Username != "user")
                {
                    var res = new TravelsWindow(loggedInUser, travelManager, travelManager.GetTravels(loggedInUser.Username));
                    res.Show();

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj ett land.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close AddTravelWindow without saving travel details
            Close();
        }


    }
}