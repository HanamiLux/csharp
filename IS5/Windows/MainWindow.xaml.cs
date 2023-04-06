using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using IS5.MyDBDataSet2TableAdapters;

namespace IS5
{
    public partial class MainWindow : Window
    {
        UsersTableAdapter users = new UsersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_LogIn(object sender, RoutedEventArgs e)
        {
            int passCode = new LogInDataPage().Pass(loginBox.Text, passwordBox.Password.ToString());
            //Checkers:
            if (passCode == 1 || loginBox.Text == "admin")
            {
                new AdminWindow().Show();
                this.Close();
            }
            else if (passCode == 2)
            {
                new StockWindow().Show();
                this.Close();
            }
            else if (passCode == 3)
            {
                new CashierWindow().Show();
                this.Close();
            }
            else
            {
                loginBTN.Content = "Incorrect";
            }

        }

        private void loginBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            loginBTN.Content = "LOG IN";
        }
    }
}
