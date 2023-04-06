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
    /// Логика взаимодействия для ManufacturersPage.xaml
    /// </summary>
    public partial class ManufacturersPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public ManufacturersPage()
        {
            InitializeComponent();
            RefreshData();
            manufacturersCountryCMB.ItemsSource = new BuildersCompanyTableAdapter().GetData();
            manufacturersCountryCMB.DisplayMemberPath = "company";
            manufacturersCountryCMB.SelectedValuePath = "companyId";
        }

        private void manufacturersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (manufacturersDG.SelectedItem != null)
            {
                manufacturerTB.Text = (manufacturersDG.SelectedItem as DataRowView).Row[1].ToString();
                manufacturersCountryCMB.SelectedValue = (manufacturersDG.SelectedItem as DataRowView).Row[2];
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturerTB.Text != "" && manufacturersCountryCMB.SelectedItem != null && Regex.IsMatch(manufacturerTB.Text, pattern, RegexOptions.IgnoreCase))
                new BuildersTableAdapter().InsertQuery(manufacturerTB.Text, Convert.ToInt32(manufacturersCountryCMB.SelectedValue));
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturerTB.Text != "" && manufacturersDG.SelectedItem != null && manufacturersCountryCMB.SelectedItem != null && Regex.IsMatch(manufacturerTB.Text, pattern, RegexOptions.IgnoreCase))
                new BuildersTableAdapter().UpdateQuery(manufacturerTB.Text, Convert.ToInt32(manufacturersCountryCMB.SelectedValue), (int)(manufacturersDG.SelectedItem as DataRowView).Row[0]);
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(manufacturersDG.SelectedItem != null)
                new BuildersTableAdapter().DeleteQuery((int)(manufacturersDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            manufacturersDG.ItemsSource = null;
            manufacturersDG.ItemsSource = new BuildersTableAdapter().GetData();
        }
    }
}
