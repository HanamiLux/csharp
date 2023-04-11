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
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        Frame frame;
        DateTime time;
        List<DayInfo> dayInfos = MyJSON.Deserialization<DayInfo>();
        public CalendarPage(ref Frame frame)
        {
            this.frame = frame;
            InitializeComponent();
            time = DateTime.Now;
            RefreshData();
            
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            time = time.AddMonths(-1);
            RefreshData();
            
        }

        private void Button_Click_Forward(object sender, RoutedEventArgs e)
        {
            time = time.AddMonths(1);
            RefreshData();
        }
        private void RefreshData()
        {
            myLabel.Content = time.ToString("MMMM") + " " + time.ToString("yyyy");
            datePicker.SelectedDate = time;
            daysWP.Children.Clear();
            List<DayInfo> dayInfos = MyJSON.Deserialization<DayInfo>();
            dayInfos = dayInfos.Where(i => i.time.Month.ToString() == time.Month.ToString() && i.time.Year.ToString() == time.Year.ToString()).ToList();
            for (int i = 1; i < DateTime.DaysInMonth(time.Year, time.Month) + 1; i++)
            {
                var dayBox = new UserDate(ref frame);
                for(int x = 0; x < dayInfos.Count;x++)
                {
                    if (x < dayInfos.Count)
                    {
                        if (i == dayInfos[x].time.Day)
                        {
                            var isFound = true;
                            var j = 0;
                            while (isFound && j < dayInfos[x].selectionList.Count)
                            {
                                if (dayInfos[x].selectionList[j].isSelected)
                                {
                                    isFound = false;
                                    dayBox.dayModel.Foreground = Brushes.MistyRose;
                                    dayBox.dayModel.Background = new ImageBrush(new BitmapImage(new Uri("../../../" + dayInfos[x].selectionList[j].img, UriKind.RelativeOrAbsolute)));
                                }
                                if (j < dayInfos[x].selectionList.Count - 1)
                                    j++;
                            }
                        }
                    }
                }
                
                
                if (i == time.Day && time.Month == DateTime.Now.Month && time.Year == DateTime.Now.Year)
                {
                    dayBox.dayModel.Background = Brushes.HotPink;
                    dayBox.dayModel.Opacity = 0.8;
                }
                dayBox.dayModel.Tag = time.Year.ToString() + "-" + time.Month.ToString() + "-" + i.ToString();
                dayBox.dayModel.Content = i.ToString();
                daysWP.Children.Add(dayBox);
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate != null)
            {
                time = datePicker.SelectedDate.Value;
                RefreshData();
            }
        }

    }
}

