using System.Windows;

namespace travelpal
{
    public partial class TravelDetailsWindow : Window
    {
        private Travel selectedTravel;

        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            selectedTravel = travel;

            // Populate UI fields with travel details
            CityTextBox.Text = selectedTravel.City;
            CountryTextBox.Text = selectedTravel.Country;
            TravelersTextBox.Text = selectedTravel.Travelers.ToString();
            //IsWorkTripCheckBox.IsChecked = selectedTravel.IsWorkTrip;
            //AllInclusiveCheckBox.IsChecked = selectedTravel.AllInclusive;
            //MeetingDetailsTextBox.Text = selectedTravel.MeetingDetails;

            //// Load travel documents into a ListBox or any appropriate control named DocumentsListBox
            //DocumentsListBox.ItemsSource = selectedTravel.Documents;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Enable editing of travel details (unlock input fields)
            CityTextBox.IsEnabled = true;
            CountryTextBox.IsEnabled = true;
            TravelersTextBox.IsEnabled = true;
            //IsWorkTripCheckBox.IsEnabled = true;
            //AllInclusiveCheckBox.IsEnabled = true;
            //MeetingDetailsTextBox.IsEnabled = true;
            //// Enable editing of the ListBox or any other control for documents if necessary
            //DocumentsListBox.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate and save edited travel details

            // Validate input (for example, ensuring Travelers is a valid number)
            if (int.TryParse(TravelersTextBox.Text, out int travelers))
            {
                // Update selectedTravel with edited details
                selectedTravel.City = CityTextBox.Text;
                selectedTravel.Country = CountryTextBox.Text;
                selectedTravel.Travelers = travelers;
                //selectedTravel.IsWorkTrip = IsWorkTripCheckBox.IsChecked.GetValueOrDefault();
                //selectedTravel.AllInclusive = AllInclusiveCheckBox.IsChecked.GetValueOrDefault();
                //selectedTravel.MeetingDetails = MeetingDetailsTextBox.Text;

                // Close TravelDetailsWindow
                Close();
            }
            else
            {
                // Display an error message if Travelers is not a valid number
                MessageBox.Show("Invalid number of travelers. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
