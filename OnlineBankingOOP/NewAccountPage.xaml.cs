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
using System.Windows.Shapes;
using BIZ;
using DAL;


namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for NewAccountPage.xaml
    /// </summary>
    public partial class NewAccountPage : Window
    {
        public NewAccountPage()
        {
            InitializeComponent();
        }

        DataEntry de = new DataEntry();

        private void Home(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string accTrype = "Savings";
            int shortcode = 101010;
            int overdraftlimit = 0;
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            try
            {
                float balance = float.Parse(txtInitDep.Text);
                SavingsAccount sa = new SavingsAccount(accTrype, shortcode, overdraftlimit, balance);
                de.RegistrationSavingsAccount(accTrype, shortcode, overdraftlimit, balance, clientid);
                MessageBox.Show("New Savings Account Opened", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                txtInitDep.Clear();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Please insert the right value", "Problem", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            



        }

        private void Canvas1_Loaded(object sender, RoutedEventArgs e)
        {
            int clientID = de.GetCurrentClientIDwithoutFn(0);
            List<string> names = de.GetAccountDetails(clientID);

            lblNewAccPage.Content = "Hello, " + names[0] + " " + names[1] + "!";
        }


    }
}
