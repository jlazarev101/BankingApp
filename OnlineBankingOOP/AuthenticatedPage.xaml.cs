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
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml.Serialization;


namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for AuthenticatedPage.xaml
    /// </summary>
    /// 
    public partial class AuthenticatedPage : Window
    {
        public AuthenticatedPage()
        {
            InitializeComponent();
        }

        SqlDataReader dr;
        CurrentAccPage cap = new CurrentAccPage();
        SavingsAccPage sap = new SavingsAccPage();
        RegistrationPage rp = new RegistrationPage();
        WithdrawPage wp = new WithdrawPage();
        TransferPage tp = new TransferPage();
        EditingPage ep = new EditingPage();
        NewAccountPage nap = new NewAccountPage();
        DepositPage dp = new DepositPage();


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            nap.Show();
        }

        private void EditAcc_Click(object sender, RoutedEventArgs e)
        {
            ep.Show();

        }
        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            dp.Show();

        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            wp.Show();
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            tp.Show();

        }
        private void TransactionsCurrent_Click(object sender, RoutedEventArgs e)
        {
            cap.Show();
        }
        private void TransactionsSavings_Click(object sender, RoutedEventArgs e)
        {
            sap.Show();
        }


        private void CurrentQuickMenu(object sender, MouseButtonEventArgs e)
        {

            cap.Show();
        }

        private void SavingsQuickMenu(object sender, MouseButtonEventArgs e)
        {
            sap.Show();
        }

        private void TransferQuickMenu(object sender, MouseButtonEventArgs e)
        {

            tp.Show();
        }

        private void WithdrawQuickMenu(object sender, MouseButtonEventArgs e)
        {

            wp.Show();
        }

        private void LogOut(object sender, MouseButtonEventArgs e)
        {
           this.Hide();
        }


        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            int clientID = de.GetCurrentClientIDwithoutFn(0);
            List<string> Fullname = de.GetAccountDetails(clientID);
            lblAdminName.Content = "Welcome Back, Mr(s) " + Fullname[1];
            string savingBal = de.GetSavingsBalance(clientID);
            string currBal = de.GetCurrentBalance(clientID);
            lblCurrentBal.Content = "$ " + currBal;
            lblSavingsBal.Content = "$ " + savingBal;

            dgv.ItemsSource = de.ViewAllAccounts(clientID).DefaultView;
        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            int clientID = de.GetCurrentClientIDwithoutFn(0);
            List<string> Fullname = de.GetAccountDetails(clientID);
            lblAdminName.Content = "Welcome Back, " + Fullname[0] + " " + Fullname[1];
            string savingBal = de.GetSavingsBalance(clientID);
            string currBal = de.GetCurrentBalance(clientID);
            lblCurrentBal.Content = "$ " + currBal;
            lblSavingsBal.Content = "$ " + savingBal;

            dgv.ItemsSource = de.ViewAllAccounts(clientID).DefaultView;
        }

        string filepath = @"C:\Users\Higs\Desktop\OnlineBankingOOP(5)\OnlineBankingOOP\OnlineBankingOOP\OnlineBankingOOP\XMLFile1.xml";
        private void btnSerialise_Click(object sender, RoutedEventArgs e)
        {
        
                Serialise s = new Serialise();
                DataEntry de = new DataEntry();
                int clientID = de.GetCurrentClientIDwithoutFn(0);
                int accNo = int.Parse(txtSerialise.Text);
                string AccountNo;
                string AccountType;
                string SortCode;
                string Balance;
                SqlCommand cmd = de.OpenCon().CreateCommand();
                cmd.CommandText = "uspSerialise";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accNo", accNo);
                dr = cmd.ExecuteReader();

                dr.Read();
                
                AccountNo = dr["AccountNo"].ToString();
                AccountType = dr["AccountType"].ToString();
                SortCode =  dr["SortCode"].ToString();
                Balance = dr["Balance"].ToString();
                
                de.CloseCon();

                XmlWriter writer;
                XmlSerializer ser;
                s.AccountNo = AccountNo;
                s.AccountType = AccountType;
                s.SortCode = SortCode;
                s.Balance = Balance;
                s.ClientID = clientID.ToString();
                ser = new XmlSerializer(typeof(Serialise));
                writer = XmlWriter.Create(filepath);
                ser.Serialize(writer, s);
                writer.Close();

                MessageBox.Show("XML File Created");
        }
    }
 }

