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
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public RolesPage()
        {
            InitializeComponent();
            RefreshData();
        }

        private void rolesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rolesDG.SelectedItem != null)
            nameTB.Text = (rolesDG.SelectedItem as DataRowView).Row[1].ToString();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(nameTB.Text != "" && Regex.IsMatch(nameTB.Text, pattern, RegexOptions.IgnoreCase))
                new RolesTableAdapter().InsertQuery(nameTB.Text);
            else
                MessageBox.Show("NameTB is incorrect!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTB.Text != "" && rolesDG.SelectedItem != null && Regex.IsMatch(nameTB.Text, pattern, RegexOptions.IgnoreCase))
                new RolesTableAdapter().UpdateQuery(nameTB.Text, (int)(rolesDG.SelectedItem as DataRowView).Row[0]);
            else
                MessageBox.Show("NameTB is incorrect!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            new RolesTableAdapter().DeleteQuery((int)(rolesDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            rolesDG.ItemsSource = null;
            rolesDG.ItemsSource = new RolesTableAdapter().GetData();
        }
    }
}
