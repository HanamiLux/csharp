using IS5.Pages;
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
    /// Логика взаимодействия для CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public CashierWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Buy(object sender, RoutedEventArgs e)
        {
            frame.Content = new BuyPage();
        }

        private void Button_Click_SavedChecks(object sender, RoutedEventArgs e)
        {
            frame.Content = new SavedChecksPage();
        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            frame.Content = new OrdersPage();
        }
        private void frame_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            frame.Refresh();
        }
    }
}
