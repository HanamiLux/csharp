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
    /// Логика взаимодействия для TiersPage.xaml
    /// </summary>
    public partial class TiersPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public TiersPage()
        {
            InitializeComponent();
            RefreshData();
        }

        private void tiersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiersDG.SelectedItem != null)
                tierTB.Text = (tiersDG.SelectedItem as DataRowView).Row[1].ToString();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tierTB.Text != "" && Regex.IsMatch(tierTB.Text, pattern, RegexOptions.IgnoreCase))
                new TiersTableAdapter().InsertQuery(tierTB.Text);
            else
                MessageBox.Show("INCORRECT FIELDS!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tierTB.Text != "" && tiersDG.SelectedItem != null && Regex.IsMatch(tierTB.Text, pattern, RegexOptions.IgnoreCase))
                new TiersTableAdapter().UpdateQuery(tierTB.Text, (int)(tiersDG.SelectedItem as DataRowView).Row[0]);
            else
                MessageBox.Show("INCORRECT FIELDS!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tiersDG.SelectedItem != null)
                new TiersTableAdapter().DeleteQuery((int)(tiersDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            tiersDG.ItemsSource = null;
            tiersDG.ItemsSource = new TiersTableAdapter().GetData();
        }

        private void ImportData_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Tier> importedData = MyJSON.Deserialization<List<Tier>>();
            foreach (var item in importedData)
            {
                new TiersTableAdapter().InsertQuery(item.tier);
            }
            RefreshData();
            
        }
    }
}
