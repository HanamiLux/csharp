using IS5.MyDBDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace IS5
{
    /// <summary>
    /// Логика взаимодействия для SavedChecksPage.xaml
    /// </summary>
    public partial class SavedChecksPage : Page
    {
        double sum = 0;
        string time = string.Empty;
        public SavedChecksPage()
        {
            InitializeComponent();
            checksCMB.ItemsSource = new OrdersTableAdapter().GetData();
            checksCMB.SelectedValuePath = "orderId";
            checksCMB.DisplayMemberPath = "orderId";
            sum = 0;

        }

        private void ExportCheck_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(checksCMB.SelectedValue != null)
            {
                double payed = (double)new SavedChecksTableAdapter().GetMoneyPayed(Convert.ToInt32(checksCMB.SelectedValue));
                
                var text = $"\t\tЖилой комплекс \"SoBaka\"\t\t\n\t\tКассовый чек №{Convert.ToInt32(checksCMB.SelectedValue)}\n\n";
                foreach (DataRowView item in checkDG.Items)
                {
                    text += $"\t{item.Row[0]}\t<<@>>\t\t{item.Row[1]}\n";
                }
                text += $"\nИтого к оплате: {sum}\nВнесено: {payed}\nСдача: {payed - sum}\nВремя: {time}";
                File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Transaction №{Convert
                    .ToInt32(checksCMB.SelectedValue)}.txt", text);
            }
                
        }

        private void checksCMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            employeeLabel.Content = "Employee:";
            SumLabel.Content = "Summary:";
            Payed.Content = "Payed:";
            timestamp.Content = "Date:";
            checkDG.ItemsSource = new SavedChecksTableAdapter().GetData(Convert.ToInt32(checksCMB.SelectedValue));
            employeeLabel.Content = employeeLabel.Content.ToString() + " " + new OrdersTableAdapter().ScalarQuery((checksCMB.SelectedItem as DataRowView).Row[1].ToString());
            foreach (DataRowView row in checkDG.Items)
            {
                sum += (double)row.Row[1];
            }
            SumLabel.Content = SumLabel.Content.ToString() + " " + sum.ToString();
            Payed.Content = Payed.Content.ToString() + " " + new SavedChecksTableAdapter().GetMoneyPayed(Convert.ToInt32(checksCMB.SelectedValue)).ToString();
            time = new SavedChecksTableAdapter().GetTimePayed(Convert.ToInt32(checksCMB.SelectedValue)).ToString();
            timestamp.Content = timestamp.Content.ToString() + " " + time;
        }
    }
}
