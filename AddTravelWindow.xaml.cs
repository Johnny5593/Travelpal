using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace travelpal
{
    public partial class AddTravelWindow : Window
    {
        private TravelManager travelManager;

        public AddTravelWindow(TravelManager manager)
        {
            InitializeComponent();
            travelManager = manager;


            List<string> countries = new List<string>
            {
                "Morroco", "Danmark", "Storbritannien", "Japan", "Jamaica", "Spanien"
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input and save the travel details
            // You need to add logic to create a new Travel object and save it to the TravelManager
            if (CountryComboBox.SelectedItem != null)
            {
                Travel newTravel = new Travel
                {
                    City = CityTextBox.Text,
                    Country = CountryComboBox.SelectedItem.ToString()
                    // You can add other properties like Travelers, IsWorkTrip, MeetingDetails, etc. here
                };

                // Add the new travel to the TravelManager
                travelManager.AddTravel(newTravel);
                Close();
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
