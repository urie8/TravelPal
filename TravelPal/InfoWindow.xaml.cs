using System.Windows;
using TravelPal.Repositories;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {

        public InfoWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(UserManager.CurrentSignedInUser);
            travelsWindow.Show();
            Close();

        }
    }
}
