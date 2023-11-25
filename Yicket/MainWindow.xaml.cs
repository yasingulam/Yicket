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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;

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

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Your existing code for the Login button click event
            // ...

            // Google OAuth code
            string clientId = "948999543717-1rnpjjgt66i0vaqmpcn6rh44ol5k7ldi.apps.googleusercontent.com";
            string clientSecret = "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";
            string redirectUri = "http://localhost";

            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                Scopes = new[] { "openid", "email", "profile" },
                DataStore = new FileDataStore("CredentialCacheFolder"),
            };

            var flow = new GoogleAuthorizationCodeFlow(initializer);

            var authCodeRequestUrl = flow.CreateAuthorizationCodeRequest(redirectUri);

            // Open the URL in a browser window or web view
            // After the user grants permission, Google will redirect to your redirect URI with an authorization code.

            // Handle the authorization code when your application receives it
            string authorizationCode = "AUTHORIZATION_CODE_FROM_REDIRECT";

            try
            {
                var token = await flow.ExchangeCodeForTokenAsync("user", authorizationCode, redirectUri, CancellationToken.None);
                string accessToken = token.AccessToken;

                // Use the access token to make requests on behalf of the user
                // ...
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                MessageBox.Show($"Error during token exchange: {ex.Message}");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // assume a successful login if the username is "demo" and the password is "demo".
            return (username == "demo" && password == "demo");
        }
    }
}