using System.Windows;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private IUser currentUser;
        public TravelsWindow(IUser user)
        {
            currentUser = user;

            InitializeComponent();

            lblUsername.Content = user.Username;

        }
    }
}
