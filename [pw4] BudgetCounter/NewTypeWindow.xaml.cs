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

namespace Budget
{
    /// <summary>
    /// Логика взаимодействия для NewTypeWindow.xaml
    /// </summary>
    public partial class NewTypeWindow : Window
    {
        public string newTyped;
        public bool isSaveType = false;
        public NewTypeWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            newTyped = newTextBox.Text;
            isSaveType = true;
            Close();
        }
    }
}
