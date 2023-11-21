using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");
                // Here you can navigate to the next screen or perform other actions.
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.");
            }
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            //assume a successful account creation if both username and password are non-empty.
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Account created successfully!");
                // Here you can navigate to the next screen or perform other actions.
            }
            else
            {
                MessageBox.Show("Account creation failed. Please enter a valid username and password.");
            }

        }
        private bool AuthenticateUser(string username, string password)
        {
            // assume a successful login if the username is "demo" and the password is "demo".
            return (username == "demo" && password == "demo");
        }
    }
}