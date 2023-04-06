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
    /// Логика взаимодействия для CountriesPage.xaml
    /// </summary>
    public partial class CountriesPage : Page
    {
        string pattern = @"^[A-z]$";
        object lastSelected;
        public CountriesPage()
        {
            InitializeComponent();
            RefreshData();
        }

        private void manufacturersCountriesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(manufacturersCountriesDG.SelectedItem != null)
            {
            builderCompanyTB.Text = (manufacturersCountriesDG.SelectedItem as DataRowView).Row[1].ToString();
                lastSelected = manufacturersCountriesDG.SelectedItem;
            }
        }

        private void suppliersCountriesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suppliersCountriesDG.SelectedItem != null)
            {
                realtorCompanyTB.Text = (suppliersCountriesDG.SelectedItem as DataRowView).Row[1].ToString();
                lastSelected = suppliersCountriesDG.SelectedItem;
            }       
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (builderCompanyTB.Text != "" && Regex.IsMatch(builderCompanyTB.Text, pattern, RegexOptions.IgnoreCase))
            {
                new BuildersCompanyTableAdapter().InsertQuery(builderCompanyTB.Text);
                if (realtorCompanyTB.Text != "" && Regex.IsMatch(realtorCompanyTB.Text, pattern, RegexOptions.IgnoreCase))
                    new RealtorsCompanyTableAdapter().InsertQuery(realtorCompanyTB.Text);
            }
            else
            {
                if (realtorCompanyTB.Text != "" && Regex.IsMatch(realtorCompanyTB.Text, pattern, RegexOptions.IgnoreCase))
                    new RealtorsCompanyTableAdapter().InsertQuery(realtorCompanyTB.Text);
                else
                    MessageBox.Show("INCORRECT FIELDS!");
            }
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (builderCompanyTB.Text != "" && manufacturersCountriesDG.SelectedItem != null && Regex.IsMatch(builderCompanyTB.Text, pattern, RegexOptions.IgnoreCase))
                new BuildersCompanyTableAdapter().UpdateQuery(builderCompanyTB.Text , (int)(manufacturersCountriesDG.SelectedItem as DataRowView).Row[0]);
            else MessageBox.Show("INCORRECT FIELDS!");
            RefreshData();
        }
        private void Edit2_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (realtorCompanyTB.Text != "" && suppliersCountriesDG.SelectedItem != null && Regex.IsMatch(realtorCompanyTB.Text, pattern, RegexOptions.IgnoreCase))
                new RealtorsCompanyTableAdapter().UpdateQuery(realtorCompanyTB.Text, (int)(suppliersCountriesDG.SelectedItem as DataRowView).Row[0]);
            else MessageBox.Show("INCORRECT FIELDS!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(suppliersCountriesDG.SelectedItem!= null && (lastSelected as DataRowView).Row.Table == (suppliersCountriesDG.SelectedItem as DataRowView).Row.Table)
                new RealtorsCompanyTableAdapter().DeleteQuery((int)(suppliersCountriesDG.SelectedItem as DataRowView).Row[0]);
            else if(manufacturersCountriesDG.SelectedItem !=null && (lastSelected as DataRowView).Row.Table == (manufacturersCountriesDG.SelectedItem as DataRowView).Row.Table)
                new BuildersCompanyTableAdapter().DeleteQuery((int)(manufacturersCountriesDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            manufacturersCountriesDG.ItemsSource = null;
            manufacturersCountriesDG.ItemsSource = new BuildersCompanyTableAdapter().GetData();
            suppliersCountriesDG.ItemsSource = null;
            suppliersCountriesDG.ItemsSource = new RealtorsCompanyTableAdapter().GetData();
        }

    }
}
