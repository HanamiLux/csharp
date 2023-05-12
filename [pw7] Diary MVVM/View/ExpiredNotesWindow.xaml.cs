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
using Diary.ViewModel;

namespace Diary.View
{
    /// <summary>
    /// Логика взаимодействия для ExpiredNotesWindow.xaml
    /// </summary>
    public partial class ExpiredNotesWindow : Window
    {
        public ExpiredNotesWindow()
        {
            InitializeComponent();
            var vm = new ExpiredNotesViewModel();
            DataContext = vm;
            vm.onRequestClose += (s, e) => this.Close();
        }
    }
}
