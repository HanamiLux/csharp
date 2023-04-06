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

namespace IS5
{
    /// <summary>
    /// Логика взаимодействия для StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        public StockWindow()
        {
            InitializeComponent();
        }
        private void frame_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            frame.Refresh();
        }
        private void Button_Click_Goods(object sender, RoutedEventArgs e)
        {
            frame.Content = new GoodsPage();
        }

        private void Button_Click_Countries(object sender, RoutedEventArgs e)
        {
            frame.Content = new CountriesPage();
        }

        private void Button_Click_Manufacturers(object sender, RoutedEventArgs e)
        {
            frame.Content = new ManufacturersPage();
        }

        private void Button_Click_Suppliers(object sender, RoutedEventArgs e)
        {
            frame.Content = new SupplierPage();
        }

        private void Button_Click_Types(object sender, RoutedEventArgs e)
        {
            frame.Content = new TypesPage();
        }

        private void Button_Click_Tiers(object sender, RoutedEventArgs e)
        {
            frame.Content = new TiersPage();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
