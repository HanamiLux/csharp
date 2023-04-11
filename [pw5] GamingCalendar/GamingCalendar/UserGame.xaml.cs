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
    /// Логика взаимодействия для UserGame.xaml
    /// </summary>
    public partial class UserGame : UserControl
    {
        public Paragraph Paragraph { get; private set; }
        public UserGame(Paragraph paragraph)
        {
            Paragraph = paragraph;
            InitializeComponent();

            labelName.Content = paragraph.name.ToString();
            img.Source = new BitmapImage(new Uri(paragraph.img, UriKind.RelativeOrAbsolute));
            checkBox.IsChecked = paragraph.isSelected;
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            Paragraph.isSelected = (bool)checkBox.IsChecked;
        }
    }
}
