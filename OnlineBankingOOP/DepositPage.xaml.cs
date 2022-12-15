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
    /// Interaction logic for DepositPage.xaml
    /// </summary>
    public partial class DepositPage : Window
    {
        public DepositPage()
        {
            InitializeComponent();
        }

        SqlDataReader dr;
        DataEntry de = new DataEntry();

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

        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            PopulateCombo(clientid);
        }

        private void btnConfirmDeposit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string AccountNo = cmbAccounts.SelectionBoxItem.ToString();
                float dep = float.Parse(txtAmount.Text);
                string transType = "Deposit";
                string accType = de.GetAccountType(AccountNo);
                int clientid = de.GetCurrentClientIDwithoutFn(0);
                string balance = de.GetBalance(AccountNo);
                float newbal = float.Parse(balance) + dep;
                de.UpdateBalance(newbal, AccountNo);

                de.RegistrationTransaction(transType, dep, accType, AccountNo, AccountNo, clientid);
                MessageBox.Show($"Transaction Success!\nYou have deposited ${dep}\nYour new balance is ${newbal}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtAmount.Clear();
            }
            catch
            {
                MessageBox.Show("Invalid Entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }


    }
}
