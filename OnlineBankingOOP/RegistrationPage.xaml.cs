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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BIZ;
using DAL;


namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
            cmbCounties.ItemsSource = Enum.GetValues(typeof(Counties));

        }

        

        private void GoBack(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
           
        }

        private void NewAccRegistration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are at the registration page already.", Title, MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void BtnConfirmDetails(object sender, RoutedEventArgs e)
        {   
            AuthenticatedPage ap = new AuthenticatedPage();
            
            //ENCRYPTING PASSWORD
            HashPass hp = new HashPass();

            //LOGIN DETAILS


            try
            {
                string Username = txtUsername.Text;
                string Password = hp.Passhash(txtPassword.Text);
                string FirstName = txtFn.Text;
                string SurName = txtSn.Text;
                string Email = txtEmail.Text;
                string Phone = txtPhone.Text;
                string Address1 = txtAddr1.Text;
                string Address2 = txtAddr2.Text;
                string City = txtCity.Text;
                string County = cmbCounties.Text.ToString();
                float IniDep = float.Parse(txtIniDep.Text);
                //PERSONAL DETAILS
                int SortCode = 101010;
                int Overdraft = -50;
                //BANKING DETAILS
                string AccType = "Current";
                //SETTING VARIABLES AND POPULATING TABLES

                LoginDetails ld = new LoginDetails(Username, Password, FirstName);
                Person p = new Person(FirstName, SurName, Email, Phone, Address1, Address2, City, County);
                CurrentAccount ca = new CurrentAccount(AccType, SortCode, IniDep, Overdraft);



                DataEntry de = new DataEntry();
                de.RegistrationALL(FirstName, SurName, Email, Phone, Address1, Address2, City, County, Username, Password, AccType, IniDep, SortCode, Overdraft);

                //CLEARING FIELDS FORM

                txtFn.Clear();
                txtSn.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtAddr1.Clear();
                txtAddr2.Clear();
                txtCity.Clear();
                txtIniDep.Clear();
                txtUsername.Clear();
                txtPassword.Clear();


                MessageBox.Show("You can now Log into your account!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Invalid entry. Please check details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



    }
}
