using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Diary.ViewModel;

namespace Diary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }

}
