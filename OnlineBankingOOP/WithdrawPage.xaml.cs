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
using System.Data.SqlClient;
using System.Data;


namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for WithdrawPage.xaml
    /// </summary>
    public partial class WithdrawPage : Window
    {
        public WithdrawPage()
        {
            InitializeComponent();
            
        }

        SqlDataReader dr;
        DataEntry de = new DataEntry();
       

        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }


        private void btnConfirmWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float wAmount = float.Parse(txtAmount.Text);
                string transType = "Withdraw";
                string AccountNo = cmbAccounts.SelectionBoxItem.ToString();
                float balance = float.Parse(de.GetBalance(AccountNo));
                int overdraftlimit = int.Parse(de.GetOverdraftlimit(AccountNo));
                float maxWithdraw = (overdraftlimit - balance) * -1;
                float newbal = balance - wAmount;


                //parameters registration transaction table
                string accType = de.GetAccountType(AccountNo);
                int clientid = de.GetCurrentClientIDwithoutFn(0);


                if (wAmount <= 0)
                {
                    MessageBox.Show($"You cannot withdraw negative amount!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (wAmount <= balance)
                {
                    de.UpdateBalance(newbal, AccountNo);
                    de.RegistrationTransaction(transType, wAmount, accType, AccountNo, AccountNo, clientid);
                    MessageBox.Show($"Transaction Success\nYou have withdrawn ${wAmount}\nYour new balance is ${newbal}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (balance - wAmount >= overdraftlimit)
                {
                    de.RegistrationTransaction(transType, wAmount, accType, AccountNo, AccountNo, clientid);
                    de.UpdateBalance(newbal, AccountNo);
                    MessageBox.Show($"Transaction Success\nYou have withdrawn ${wAmount}\nYour new balance is ${newbal}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"You have not enough funds\nYour max withdrawl is ${maxWithdraw}", "Problem", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                txtAmount.Clear();
            }
            catch
            {
                MessageBox.Show("Invalid entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        public void PopulateCombo(int clientid)
        {
            SqlCommand cmd = de.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllAccounts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientid);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountNo"].ToString();
                cmbAccounts.Items.Add(acc);
               
            }
            de.CloseCon();


        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            PopulateCombo(clientid);
            

        }

        private void cmbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
