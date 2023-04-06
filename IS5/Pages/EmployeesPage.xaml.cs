using IS5.MyDBDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        string pattern = @"^[A-z]$";
        public EmployeesPage()
        {
            InitializeComponent();
            roleCMB.ItemsSource = new RolesTableAdapter().GetData();
            roleCMB.SelectedValuePath = "roleId";
            roleCMB.DisplayMemberPath = "roleName";
            RefreshData();
        }

        private void usersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(usersDG.SelectedItem != null)
            {
                lastNameTB.Text = (usersDG.SelectedItem as DataRowView).Row[1].ToString();
                firstNameTB.Text = (usersDG.SelectedItem as DataRowView).Row[2].ToString();
                roleCMB.SelectedValue = (usersDG.SelectedItem as DataRowView).Row[3];
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (lastNameTB.Text != "" && firstNameTB.Text != "" 
                && roleCMB.SelectedValue != null && Regex.IsMatch(firstNameTB.Text, pattern, RegexOptions.IgnoreCase) && Regex.IsMatch(lastNameTB.Text, pattern, RegexOptions.IgnoreCase))
                new EmployeesTableAdapter().InsertQuery(lastNameTB.Text, firstNameTB.Text, Convert.ToInt32(roleCMB.SelectedValue));
            else MessageBox.Show("Проверка moment*");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (lastNameTB.Text != "" && firstNameTB.Text != "" && roleCMB.SelectedValue != null && usersDG.SelectedItem != null && Regex.IsMatch(firstNameTB.Text, pattern, RegexOptions.IgnoreCase) && Regex.IsMatch(lastNameTB.Text, pattern, RegexOptions.IgnoreCase))
                new EmployeesTableAdapter().UpdateQuery(lastNameTB.Text, firstNameTB.Text, Convert.ToInt32(roleCMB.SelectedValue), (int)(usersDG.SelectedItem as DataRowView).Row[0]);
            else MessageBox.Show("Проверка moment*");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (usersDG.SelectedItem != null)
                new EmployeesTableAdapter().DeleteQuery((int)(usersDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            usersDG.ItemsSource = null;
            usersDG.ItemsSource = new EmployeesTableAdapter().GetData();
        }
    }
}
