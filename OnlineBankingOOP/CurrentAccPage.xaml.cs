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
    /// Interaction logic for CurrentAccPage.xaml
    /// </summary>
    public partial class CurrentAccPage : Window
    {
        
        public CurrentAccPage()
        {
            InitializeComponent();
            
        }

        private void Canvas_Loaded_1(object sender, RoutedEventArgs e)
        {
     
            DataEntry de = new DataEntry();
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            dgv.ItemsSource = de.GetCurrentTransaction(clientid).DefaultView;
            lblCurrentBal.Content = "$ " + de.GetCurrentBalance(clientid);
        }

        private void Home(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            int clientid = de.GetCurrentClientIDwithoutFn(0);
            dgv.ItemsSource = de.GetCurrentTransaction(clientid).DefaultView;
            lblCurrentBal.Content = "$ " + de.GetCurrentBalance(clientid);
        }
    }
}
