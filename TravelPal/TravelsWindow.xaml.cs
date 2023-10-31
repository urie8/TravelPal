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
        public TravelsWindow(IUser user)
        {
            InitializeComponent();

            lblUsername.Content = user.Username;
            lstTravels.Items.Clear();

            // Checks if the current signed in user is an admin, if it is then the add button is disabled and every travel from every user is added to the list.
            if (user.GetType() == typeof(Admin))
            {
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
            ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;

            TravelDetailsWindow newTravelDetailsWindow = new((Travel)selectedItem.Tag);
            newTravelDetailsWindow.Show();
            Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Kolla vilken resa som är selectad
            ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;
            Travel selectedTravel = (Travel)selectedItem.Tag;

            // Kolla om vi är admin eller user
            if (UserManager.CurrentSignedInUser.GetType() == typeof(User))
            {
                currentUser = (User)UserManager.CurrentSignedInUser;
                currentUser.Travels.Remove(selectedTravel);
                lstTravels.Items.Remove(selectedItem);

            }

            else if (UserManager.CurrentSignedInUser.GetType() == typeof(Admin))
            {
                TravelManager.Travels.Remove(selectedTravel);
                lstTravels.Items.Remove(selectedItem);

                foreach (IUser user in UserManager.Users)
                {
                    if (user.GetType() == typeof(User))
                    {
                        User loopedUser = (User)user;

                        foreach (Travel travel in loopedUser.Travels)
                        {
                            if (selectedTravel.Id == travel.Id)
                            {
                                loopedUser.Travels.Remove(travel);
                                break;
                            }
                        }
                    }
                }

            }
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
