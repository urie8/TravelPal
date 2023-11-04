using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Models;
using TravelPal.Repositories;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        Travel Travel;
        public TravelDetailsWindow(Travel travel)
        {
            Travel = travel;
            InitializeComponent();

            cbTripType.Items.Add("Vacation");
            cbTripType.Items.Add("Worktrip");
            cbCountry.ItemsSource = Enum.GetValues(typeof(Country));

            txtCity.Text = Travel.Destination;
            cbCountry.SelectedItem = Travel.Country;
            txtTravellers.Text = Travel.Travellers.ToString();
            calStartDate.Text = Travel.StartDate.ToString();
            calEndDate.Text = Travel.EndDate.ToString();

            foreach (PackingListItem item in Travel.PackingList)
            {
                ListViewItem listViewItem = new();
                listViewItem.Tag = item;
                listViewItem.Content = item.GetInfo();
                lstPackingList.Items.Add(listViewItem);
            }

            if (Travel.GetType() == typeof(WorkTrip))
            {
                WorkTrip workTrip = (WorkTrip)Travel;
                cbTripType.SelectedItem = "Worktrip";

                lblMeeting.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Visible;
                txtMeetingDetails.Text = workTrip.MeetingDetails;
            }

            else if (Travel.GetType() == typeof(Vacation))
            {
                Vacation vacation = (Vacation)Travel;
                cbTripType.SelectedItem = "Vacation";

                lblAllInclusive.Visibility = Visibility.Visible;
                if (vacation.AllInclusive)
                {
                    ckbAllInclusive.Visibility = Visibility.Visible;
                    ckbAllInclusive.IsChecked = true;
                }
                else
                {
                    ckbAllInclusive.Visibility = Visibility.Visible;
                }
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(UserManager.CurrentSignedInUser);
            travelsWindow.Show();
            Close();
        }
    }
}
