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
using System.Data.SqlClient;
using System.Data;

namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for TransferPage.xaml
    /// </summary>
    public partial class TransferPage : Window
    {
        public TransferPage()
        {
            InitializeComponent();
            
        }

        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }

        DataEntry de = new DataEntry();
        SqlDataReader dr;

        public void btnConfirmTransfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string accountSender = cmbSender.SelectionBoxItem.ToString();
                string accountReceiver = cmbReceiver.SelectionBoxItem.ToString();
                float amount = float.Parse(txtAmount.Text);
                float balanceSender = float.Parse(de.GetBalance(accountSender));
                float balanceReceiver = float.Parse(de.GetBalance(accountReceiver));

                int overdraftlimit = int.Parse(de.GetOverdraftlimit(accountSender));
                float maxWithdraw = (overdraftlimit - balanceSender) * -1;
                float newbalsender = balanceSender - amount;
                float newbalreceiver = balanceReceiver + amount;

                //parameters registration transaction table
                string transType = "Transfer";
                string accType = de.GetAccountType(accountSender);
                int clientid = de.GetCurrentClientIDwithoutFn(0);


                if (amount <= 0)
                {
                    MessageBox.Show($"You cannot transfer negative amount!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (amount <= balanceSender)
                {
                    de.UpdateBalance(newbalsender, accountSender);
                    de.UpdateBalance(newbalreceiver, accountReceiver);
                    de.RegistrationTransaction(transType, amount, accType, accountSender, accountReceiver, clientid);
                    MessageBox.Show($"Transaction Success\nYou have transferred ${amount}\nTo Account Number: {accountReceiver}.\nYour new balance is ${newbalsender}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (balanceSender - amount >= overdraftlimit)
                {
                    de.RegistrationTransaction(transType, amount, accType, accountSender, accountReceiver, clientid);
                    de.UpdateBalance(newbalsender, accountSender);
                    de.UpdateBalance(newbalreceiver, accountReceiver);

                    MessageBox.Show($"Transaction Success\nYou have transferred ${amount}\nTo Account Number: {accountReceiver}.\nYour new balance is ${newbalsender}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"You have not enough funds!\nYou can only transfer up to ${maxWithdraw}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }



                txtAmount.Clear();
            }
            catch
            {
                MessageBox.Show("Invalid Entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            PopulateCombo(clientid);
            PopulateReceiversCombo(clientid);
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
                string AccountNo = dr["AccountNo"].ToString();
                cmbSender.Items.Add(AccountNo);

            }

            de.CloseCon();

        }
        public void PopulateReceiversCombo(int clientid)
        {
            SqlCommand cmd = de.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllAccountsExceptCurrentClientID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clientid", clientid);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string AccountNo = dr["AccountNo"].ToString();
                cmbReceiver.Items.Add(AccountNo);

            }
            de.CloseCon();

        }
     


    }
}
