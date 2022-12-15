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
using DAL;
using BIZ;

namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for EditingPage.xaml
    /// </summary>
    public partial class EditingPage : Window
    {
        public EditingPage()
        {
           

            InitializeComponent();
           

        }

        DataEntry de = new DataEntry();
        HashPass hp = new HashPass();


        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }


        private void BtnUpdateDetails(object sender, RoutedEventArgs e)
        {
           
       
            string user = txtUsername.Text;
            string password = hp.Passhash(txtPassword.Text);
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string add1 = txtAddr1.Text;
            string add2 = txtAddr2.Text;
            string city = txtCity.Text;
            string Cy = cmbCounties.Text.ToString();
            int clientID = de.GetCurrentClientIDwithoutFn(0);
            if(user == "" || password == "" || email == "" || phone == "" || add1 == "" || city == "" || Cy == "")
            {
                MessageBox.Show("Invalid Entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                de.UpdateClientDetails(user, password, email, phone, add1, add2, city, Cy, clientID);

                MessageBox.Show("Details Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                txtEmail.Clear();
                txtPhone.Clear();
                txtAddr1.Clear();
                txtAddr2.Clear();
                txtCity.Clear();
                txtUsername.Clear();
                txtPassword.Clear();

                this.Hide();

            }

        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            int clientID = de.GetCurrentClientIDwithoutFn(0);
            List<string> names = de.GetAccountDetails(clientID);

            lblFn.Content = names[0];
            lblSn.Content = names[1];

            cmbCounties.ItemsSource = Enum.GetValues(typeof(Counties));


            string savingBal = de.GetSavingsBalance(clientID);
            string currBal = de.GetCurrentBalance(clientID);
            dgv.ItemsSource = de.ViewAllAccounts(clientID).DefaultView;
        }
    }
}
