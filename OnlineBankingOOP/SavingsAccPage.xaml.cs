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

namespace OnlineBankingOOP
{
    /// <summary>
    /// Interaction logic for SavingsAccPage.xaml
    /// </summary>
    public partial class SavingsAccPage : Window
    {
        

        public SavingsAccPage()
        {
            InitializeComponent();

            

          
        }

        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            lblSavingsBal.Content = "$ " + de.GetSavingsBalance(clientid);
            dgv.ItemsSource = de.GetSavingsTransaction(clientid).DefaultView;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            lblSavingsBal.Content = "$ " + de.GetSavingsBalance(clientid);
            dgv.ItemsSource = de.GetSavingsTransaction(clientid).DefaultView;
        }
    }
}
