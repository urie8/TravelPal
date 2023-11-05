using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Repositories;
using TravelPal.Utilities;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>s
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            cbCountries.ItemsSource = Enum.GetValues(typeof(Country));
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Please type in a username", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPassword.Password == string.Empty)
            {
                MessageBox.Show("Please type in a password", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cbCountries.SelectedItem == null)
            {

                MessageBox.Show("Please select a country", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
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

                catch (InvalidUsernameException ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
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
