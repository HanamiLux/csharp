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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Roles(object sender, RoutedEventArgs e)
        {
             frame.Content = new RolesPage();
        }

        private void Button_Click_Employees(object sender, RoutedEventArgs e)
        {
            frame.Content = new EmployeesPage();
        }

        private void Button_Click_LogInData(object sender, RoutedEventArgs e)
        {
            frame.Content = new LogInDataPage();
        }

        private void frame_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            frame.Refresh();
        }
    }
}
