using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        User User { get; set; }
        public AddTravelWindow(User user)
        {
            User = user;
            InitializeComponent();

            cbTripType.Items.Add("Vacation");
            cbTripType.Items.Add("Worktrip");

            cbCountry.ItemsSource = Enum.GetValues(typeof(Country));

        }
        private void cbCountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (Enum.IsDefined(typeof(EuropeanCountry), User.Location.ToString()) && !Enum.IsDefined(typeof(EuropeanCountry), cbCountry.SelectedItem.ToString()))
            {
                TravelDocument travelDocument = new("Passport", true);

                ListViewItem item = new();
                item.Tag = travelDocument;
                item.Content = travelDocument.GetInfo();
                lstPackingList.Items.Add(item);


            }
        }
        private void cbTripType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbTripType.SelectedItem == "Vacation")
            {
                lblAllInclusive.Visibility = Visibility.Visible;
                ckbAllInclusive.Visibility = Visibility.Visible;

                lblMeeting.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Hidden;
            }
            else if (cbTripType.SelectedItem == "Worktrip")
            {
                lblMeeting.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Visible;

                lblAllInclusive.Visibility = Visibility.Hidden;
                ckbAllInclusive.Visibility = Visibility.Hidden;
            }

        }

        private void ckbTravelDocument_Checked(object sender, RoutedEventArgs e)
        {
            lblRequired.Visibility = Visibility.Visible;
            ckbRequired.Visibility = Visibility.Visible;

            lblQuantitys.Visibility = Visibility.Hidden;
            txtQuantity.Visibility = Visibility.Hidden;


        }

        private void ckbTravelDocument_Unchecked(object sender, RoutedEventArgs e)
        {
            lblRequired.Visibility = Visibility.Hidden;
            ckbRequired.Visibility = Visibility.Hidden;

            lblQuantitys.Visibility = Visibility.Visible;
            txtQuantity.Visibility = Visibility.Visible;
        }


    }
}
