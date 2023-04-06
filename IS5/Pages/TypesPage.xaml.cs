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
    /// Логика взаимодействия для TypesPage.xaml
    /// </summary>
    public partial class TypesPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public TypesPage()
        {
            InitializeComponent();
            RefreshData();
        }

        private void typesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typesDG.SelectedItem != null)
                typeTB.Text = (typesDG.SelectedItem as DataRowView).Row[1].ToString();
            
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (typeTB.Text != "" && Regex.IsMatch(typeTB.Text, pattern, RegexOptions.IgnoreCase))
                new TypeNamesTableAdapter().InsertQuery(typeTB.Text);
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (typeTB.Text != "" && typesDG.SelectedItem != null && Regex.IsMatch(typeTB.Text, pattern, RegexOptions.IgnoreCase))
                new TypeNamesTableAdapter().UpdateQuery(typeTB.Text, (int)(typesDG.SelectedItem as DataRowView).Row[0]);
            else
                MessageBox.Show("EMPTY FIELDS!");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (typesDG.SelectedItem != null)
                new TypeNamesTableAdapter().DeleteQuery((int)(typesDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            typesDG.ItemsSource = null;
            typesDG.ItemsSource = new TypeNamesTableAdapter().GetData();
        }
    }
}
