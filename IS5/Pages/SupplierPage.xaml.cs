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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public SupplierPage()
        {
            InitializeComponent();
            suppliersDG.ItemsSource = new RealtorsTableAdapter().GetData();
            suppliersCountryCMB.ItemsSource = new RealtorsCompanyTableAdapter().GetData();
            suppliersCountryCMB.DisplayMemberPath = "company";
            suppliersCountryCMB.SelectedValuePath = "companyId";
        }

        private void suppliersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suppliersDG.SelectedItem != null)
            {
                supplierTB.Text = (suppliersDG.SelectedItem as DataRowView).Row[1].ToString();
                suppliersCountryCMB.SelectedValue = (suppliersDG.SelectedItem as DataRowView).Row[2];
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (supplierTB.Text != "" && suppliersCountryCMB.SelectedItem != null && Regex.IsMatch(supplierTB.Text, pattern, RegexOptions.IgnoreCase))
                new RealtorsTableAdapter().InsertQuery(supplierTB.Text, Convert.ToInt32(suppliersCountryCMB.SelectedValue));
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (supplierTB.Text != "" && suppliersDG.SelectedItem != null && suppliersCountryCMB.SelectedItem != null && Regex.IsMatch(supplierTB.Text, pattern, RegexOptions.IgnoreCase))
                new RealtorsTableAdapter().UpdateQuery(supplierTB.Text, Convert.ToInt32(suppliersCountryCMB.SelectedValue), (int)(suppliersDG.SelectedItem as DataRowView).Row[0]);
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (suppliersDG.SelectedItem != null)
                new RealtorsTableAdapter().DeleteQuery((int)(suppliersDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            suppliersDG.ItemsSource = null;
            suppliersDG.ItemsSource = new RealtorsTableAdapter().GetData();
        }
    }
}
