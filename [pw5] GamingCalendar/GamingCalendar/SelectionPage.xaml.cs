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
    /// Логика взаимодействия для SelectionPage.xaml
    /// </summary>
    public partial class SelectionPage : Page
    {
        List<DayInfo> dayInfos = MyJSON.Deserialization<DayInfo>();
        List<UserGame> userGames = new List<UserGame>();
        string tag;
        public SelectionPage(string tag)
        {
            this.tag = tag;
            InitializeComponent();
            string [] date = tag.Split("-");
            var currentDayInfo = dayInfos.Where(i => i.time.Month.ToString() == date[1] && i.time.Year.ToString() == date[0] && i.time.Day.ToString() == date[2]).ToList();
            if (currentDayInfo.Count > 0)
            {
                foreach (var game in currentDayInfo[0].selectionList)
                {
                    var userGame = new UserGame(game);
                    userGames.Add(userGame);
                }
            }
            else
            {
                List<Paragraph> games = new List<Paragraph> { new Paragraph("Minecraft", "Images/minecraft-logo.png"), new Paragraph("Valorant", "Images/valorant-logo.png"), new Paragraph("GTA V", "Images/gtav-logo.png"), new Paragraph("Valheim", "Images/valheim-logo.png") };
                foreach (var game in games)
                {
                    var userGame = new UserGame(game);
                    userGames.Add(userGame);
                }
            }

            listBox.ItemsSource = userGames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Paragraph> pargs = new List<Paragraph>();
            foreach (var game in userGames)
            {
                pargs.Add(game.Paragraph);
            }
            dayInfos.Add(new DayInfo(new DateTime(Convert.ToInt32(tag.Split("-")[0]), Convert.ToInt32(tag.Split("-")[1]), Convert.ToInt32(tag.Split("-")[2])), pargs));
            dayInfos = dayInfos.DistinctBy(day => day.time).ToList();
            MyJSON.Serialization(dayInfos);
        }
    }
}
