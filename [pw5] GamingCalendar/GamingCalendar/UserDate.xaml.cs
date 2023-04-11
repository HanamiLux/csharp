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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamingCalendar
{
    /// <summary>
    /// Логика взаимодействия для UserDate.xaml
    /// </summary>
    public partial class UserDate : UserControl
    {
        public Frame frame;
        public UserDate(ref Frame frame)
        {
            this.frame = frame;
            InitializeComponent();
        }

        private void dayModel_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new SelectionPage(dayModel.Tag.ToString());
        }
    }
}
