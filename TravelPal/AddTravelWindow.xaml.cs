using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Models;
using TravelPal.Repositories;

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


            // If the user is located outside of EU then a passport with required set as true is added to the packinglist
            if (!Enum.IsDefined(typeof(EuropeanCountry), User.Location.ToString()))
            {
                TravelDocument travelDocument = new("Passport", true);

                ListViewItem item = new();

                item.Tag = travelDocument;
                item.Content = travelDocument.GetInfo();

                lstPackingList.Items.Add(item);
            }

        }

        private void cbCountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // If the user is located within EU and the destination is not then a passport with required set as true is added to the packinglist
            if (Enum.IsDefined(typeof(EuropeanCountry), User.Location.ToString()) && !Enum.IsDefined(typeof(EuropeanCountry), cbCountry.SelectedItem.ToString()))
            {
                TravelDocument travelDocument = new("Passport", true);

                ListViewItem item = new();
                item.Tag = travelDocument;
                item.Content = travelDocument.GetInfo();
                lstPackingList.Items.Add(item);
            }
            // If the user is located within EU and the destination is also located within EU then a passport with required set as false is added to the packinglist
            else if (Enum.IsDefined(typeof(EuropeanCountry), User.Location.ToString()) && Enum.IsDefined(typeof(EuropeanCountry), cbCountry.SelectedItem.ToString()))
            {
                TravelDocument travelDocument = new("Passport", false);

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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string name = txtPackingItem.Text;
            ListViewItem item = new();

            if (ckbTravelDocument.IsChecked == true)
            {
                if (ckbRequired.IsChecked == true)
                {
                    TravelDocument newRequiredTravelDocument = new(name, true);

                    item.Tag = newRequiredTravelDocument;
                    item.Content = newRequiredTravelDocument.GetInfo();

                    lstPackingList.Items.Add(item);

                    TextClear();
                }
                else
                {
                    TravelDocument newTravelDocument = new(name, false);

                    item.Tag = newTravelDocument;
                    item.Content = newTravelDocument.GetInfo();

                    lstPackingList.Items.Add(item);

                    TextClear();
                }
            }

            else
            {
                int quantity = int.Parse(txtQuantity.Text);

                OtherItem newItem = new(name, quantity);

                item.Tag = newItem;
                item.Content = newItem.GetInfo();

                lstPackingList.Items.Add(item);

                TextClear();

            }

        }

        private void btnAddTrip_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtCity.Text;
            Country country = (Country)cbCountry.SelectedItem;
            int travellers = int.Parse(txtTravellers.Text);
            DateTime startDate = (DateTime)calStartDate.SelectedDate;
            DateTime endDate = (DateTime)calEndDate.SelectedDate;

            if (cbTripType.SelectedItem == "Worktrip")
            {
                string meetingDetails = txtMeetingDetails.Text;

                WorkTrip newWorktrip = new(destination, country, travellers, startDate, endDate, meetingDetails);

                User.Travels.Add(newWorktrip);
                TravelManager.AddTravel(newWorktrip);

                TravelsWindow newTravelsWindow = new(User);
                newTravelsWindow.Show();
                Close();

            }
            else if (cbTripType.SelectedItem == "Vacation")
            {
                if (ckbAllInclusive.IsChecked == true)
                {
                    Vacation newVacation = new(destination, country, travellers, startDate, endDate, true);
                    User.Travels.Add(newVacation);
                    TravelManager.AddTravel(newVacation);

                    TravelsWindow newTravelsWindow = new(User);
                    newTravelsWindow.Show();
                    Close();
                }
                else
                {
                    Vacation newVacation = new(destination, country, travellers, startDate, endDate, false);
                    User.Travels.Add(newVacation);
                    TravelManager.AddTravel(newVacation);

                    TravelsWindow newTravelsWindow = new(User);
                    newTravelsWindow.Show();
                    Close();
                }
            }
        }

        private void TextClear()
        {
            txtPackingItem.Clear();
            txtQuantity.Clear();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow newTravelsWindow = new(User);
            newTravelsWindow.Show();
            Close();
        }
    }
}

