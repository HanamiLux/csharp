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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte firstTurnCode = 0;
        private byte turnCode;
        private Random rnd = new Random();
        private bool isRestarted = true;
        private List<Button> buttons = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            Turn.Content = "Turn: X";
            this.Height = 500;
            this.Width = 900;
            Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isRestarted)
            {
                turnCode = firstTurnCode;
                buttons.Clear();
                buttons.Add(Button1);
                buttons.Add(Button2);
                buttons.Add(Button3);
                buttons.Add(Button4);
                buttons.Add(Button5);
                buttons.Add(Button6);
                buttons.Add(Button7);
                buttons.Add(Button8);
                buttons.Add(Button9);
                isRestarted = false;
            }
            if (firstTurnCode == 1)
            {
                sender.GetType().GetProperty("Content").SetValue(sender, "X");
                buttons.Remove((Button)sender);
                BotTurn(0);
            }
            else if (firstTurnCode == 0)
            {
                sender.GetType().GetProperty("Content").SetValue(sender, "O");
                buttons.Remove((Button)sender);
                BotTurn(1);
            }
                WinChecker();
                sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
        }
        private void BotTurn(byte turnCode)
        {
            if(turnCode == 0)
            {
                if (buttons.Count != 0)
                {
                    int i = rnd.Next(buttons.Count);
                    buttons[i].GetType().GetProperty("Content").SetValue(buttons[i], "O");
                    turnCode = 1;
                    buttons[i].GetType().GetProperty("IsEnabled").SetValue(buttons[i], false);
                    buttons.Remove(buttons[i]);
                }
            }
            else
            {
                if (buttons.Count != 0)
                {
                    int i = rnd.Next(buttons.Count);
                    buttons[i].GetType().GetProperty("Content").SetValue(buttons[i], "X");
                    turnCode = 0;
                    buttons[i].GetType().GetProperty("IsEnabled").SetValue(buttons[i], false);
                    buttons.Remove(buttons[i]);
                }
            }
        }
        private void WinChecker()
        {   //horizontal:
            if (Button1.Content == Button2.Content && Button2.Content == Button3.Content)
            {
                if (Button1.Content != "")
                {
                    Winner.Content = "Победили " + Button1.Content;
                    MessageBox.Show("Победили " + Button1.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else if (Button4.Content == Button5.Content && Button5.Content == Button6.Content)
            {
                if (Button4.Content != "")
                {
                    Winner.Content = "Победили " + Button4.Content;
                    MessageBox.Show("Победили " + Button4.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else if (Button7.Content == Button8.Content && Button8.Content == Button9.Content)
            {
                if (Button7.Content != "")
                {
                    Winner.Content = "Победили " + Button7.Content;
                    MessageBox.Show("Победили " + Button7.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            //vertical:
            else if (Button1.Content == Button4.Content && Button4.Content == Button7.Content)
            {
                if (Button1.Content != "")
                {
                    Winner.Content = "Победили " + Button1.Content;
                    MessageBox.Show("Победили " + Button1.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else if (Button2.Content == Button5.Content && Button5.Content == Button8.Content)
            {
                if (Button2.Content != "")
                {
                    Winner.Content = "Победили " + Button2.Content;
                    MessageBox.Show("Победили " + Button2.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else if (Button3.Content == Button6.Content && Button6.Content == Button9.Content)
            {
                if (Button3.Content != "")
                {
                    Winner.Content = "Победили " + Button3.Content;
                    MessageBox.Show("Победили " + Button3.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            //diagonal:
            else if (Button3.Content == Button5.Content && Button5.Content == Button7.Content)
            {
                if (Button3.Content != "")
                {
                    Winner.Content = "Победили " + Button3.Content;
                    MessageBox.Show("Победили " + Button3.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else if (Button1.Content == Button5.Content && Button5.Content == Button9.Content)
            {
                if (Button1.Content != "")
                {
                    Winner.Content = "Победили " + Button1.Content;
                    MessageBox.Show("Победили " + Button1.Content);
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            else
            {
                if (Button1.Content != "" && Button2.Content != "" && Button3.Content != "" && Button4.Content != "" && Button5.Content != "" && Button6.Content != "" && Button7.Content != "" && Button8.Content != "" && Button9.Content != "")
                {
                    Winner.Content = "DRAW";
                    MessageBox.Show("Ничья");
                    Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = false;
                }
            }
            
        }
        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            isRestarted = true;
            Button1.Content = Button2.Content = Button3.Content = Button4.Content = Button5.Content = Button6.Content = Button7.Content = Button8.Content = Button9.Content = Winner.Content = "";
            Button1.IsEnabled = Button2.IsEnabled = Button3.IsEnabled = Button4.IsEnabled = Button5.IsEnabled = Button6.IsEnabled = Button7.IsEnabled = Button8.IsEnabled = Button9.IsEnabled = true;
            if (firstTurnCode == 1)
            {
                Turn.Content = "Turn: O";
                firstTurnCode = 0;
            }
            else
            {
                Turn.Content = "Turn: X";
                firstTurnCode = 1;
            }
        }
    }
}
