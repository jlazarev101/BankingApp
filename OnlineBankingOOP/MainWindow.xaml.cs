using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using DAL;
using BIZ;

namespace OnlineBankingOOP
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

        HashPass hp = new HashPass();
        AuthenticatedPage ap = new AuthenticatedPage();
        DataEntry de = new DataEntry();
        DAO dao = new DAO();
        string user, pass;
        string login = string.Empty;

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage rp = new RegistrationPage();
            rp.Show();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //LOGIN CODE GOES HERE
            bool loginSuccessful;
            user = txtRegNumber.Text;
            pass = hp.Passhash(txtPersonalAccessCode.Password);
            loginSuccessful = de.GetUser(user, pass);
            
            if (loginSuccessful == true)
            {
                int clientID = de.GetClientIDLoginDetails(user, pass);
                de.UpdateCurrentClientID(0, clientID);
                List<string> clientFn = de.GetAccountDetails(clientID);
                MessageBox.Show($"Welcome Back, {clientFn[0]}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                ap.Show();
                txtPersonalAccessCode.Clear();
                txtRegNumber.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Credentials. Try Again or Register a new Account.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Please contact Support at BankingApp@ie.com", ContentStringFormat, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage rp = new RegistrationPage();
            rp.Show();
        }



    }
}
