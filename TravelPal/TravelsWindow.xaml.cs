using System.Windows;
using System.Windows.Controls;
using TravelPal.Models;
using TravelPal.Repositories;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private User currentUser;
        private Admin currentAdmin;
        public TravelsWindow(IUser user)
        {
            InitializeComponent();

            lblUsername.Content = user.Username;
            lstTravels.Items.Clear();

            // Checks if the current signed in user is an admin, if it is then the add button is disabled and every travel from every user is added to the list.
            if (user.GetType() == typeof(Admin))
            {
                currentAdmin = (Admin)user;
                btnAddTravel.IsEnabled = false;

                if (TravelManager.Travels != null)
                {
                    foreach (Travel travel in TravelManager.Travels)
                    {
                        ListViewItem item = new();
                        item.Tag = travel;
                        item.Content = travel.GetInfo();

                        lstTravels.Items.Add(item);
                    }
                }
            }
            // If its a normal user then only the specific users travels is added to the list of travels
            else
            {
                currentUser = (User)user;

                if (currentUser.Travels != null)
                {
                    foreach (Travel travel in currentUser.Travels)
                    {
                        ListViewItem item = new();
                        item.Tag = travel;
                        item.Content = travel.GetInfo();

                        lstTravels.Items.Add(item);
                    }
                }

            }

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(currentUser);
            addTravelWindow.Show();
            Close();

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
