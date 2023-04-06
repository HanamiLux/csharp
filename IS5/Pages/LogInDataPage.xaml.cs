using IS5.MyDBDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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


namespace IS5
{

    /// <summary>
    /// Логика взаимодействия для LogInDataPage.xaml
    /// </summary>
    public partial class LogInDataPage : Page
    {
        string pattern = @"^\w*$";
        public LogInDataPage()
        {
            InitializeComponent();
            RefreshData();
            employeeCMB.ItemsSource = new EmployeesTableAdapter().GetData();
            employeeCMB.DisplayMemberPath = "lastName";
            employeeCMB.SelectedValuePath = "employeeId";
        }
        
        public int Pass(string login, string password)
        {
            int employeeId;
            foreach (var row in logInDataDG.Items)
            {
                if ((row as DataRowView).Row[1].ToString() == login)
                    if ((row as DataRowView).Row[2].ToString() == password)
                    {
                        employeeId = (int)(row as DataRowView).Row[3];
                        logInDataDG.ItemsSource = new EmployeesTableAdapter().GetData();
                        foreach (var row2 in logInDataDG.Items)
                        {
                            if ((int)(row2 as DataRowView).Row[0] == employeeId)
                                return (int)(row2 as DataRowView).Row[3];
                        }
                    }
            }
            return 0;
        }

        private void logInDataDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (logInDataDG.SelectedItem != null)
            {
                loginTB.Text = (logInDataDG.SelectedItem as DataRowView).Row[1].ToString();
                passwordTB.Password = (logInDataDG.SelectedItem as DataRowView).Row[2].ToString();
                employeeCMB.SelectedValue = (logInDataDG.SelectedItem as DataRowView).Row[3];
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text != "" && passwordTB.Password != "" && employeeCMB.SelectedValue != null && Regex.IsMatch(loginTB.Text, pattern, RegexOptions.IgnoreCase) && Regex.IsMatch(passwordTB.Password, pattern, RegexOptions.IgnoreCase))
                new UsersTableAdapter().InsertQuery(loginTB.Text, passwordTB.Password, Convert.ToInt32(employeeCMB.SelectedValue));
            else MessageBox.Show("Incorrect fields!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text != "" && passwordTB.Password != "" && employeeCMB.SelectedValue != null && logInDataDG.SelectedItem != null && Regex.IsMatch(loginTB.Text, pattern, RegexOptions.IgnoreCase) && Regex.IsMatch(passwordTB.Password, pattern, RegexOptions.IgnoreCase))
                new UsersTableAdapter().UpdateQuery(loginTB.Text, passwordTB.Password, Convert.ToInt32(employeeCMB.SelectedValue), (int)(logInDataDG.SelectedItem as DataRowView).Row[0]);
            else MessageBox.Show("Incorrect fields!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(logInDataDG.SelectedItem != null)
            new UsersTableAdapter().DeleteQuery((int)(logInDataDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();


        }
        private void RefreshData()
        {
            logInDataDG.ItemsSource = null;
            logInDataDG.ItemsSource = new UsersTableAdapter().GetData();
        }

    }
}
