using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Repositories;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            cbCountries.ItemsSource = Enum.GetValues(typeof(Country));
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            Country country = (Country)cbCountries.SelectedItem;

            try
            {
                UserManager.AddUser(username, password, country);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }

            catch (ArgumentNullException)
            {
                MessageBox.Show("Username already in use!", "Warning", MessageBoxButton.OK);
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
