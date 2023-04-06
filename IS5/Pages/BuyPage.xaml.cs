using IS5.MyDBDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {
        double sum = 0;
        List<Good> orderedGoods = new List<Good>();
        public BuyPage()
        {
            InitializeComponent();
            allGoodsDG.ItemsSource = new GoodsTableAdapter().GetData();
            customerCMB.ItemsSource = new EmployeesTableAdapter().GetData();
            customerCMB.DisplayMemberPath = "lastName";
            customerCMB.SelectedValuePath = "employeeId";
            orderedGoods.Clear();
            refreshData();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(allGoodsDG.SelectedItem != null)
                orderedGoods.Add(new Good((allGoodsDG.SelectedItem as DataRowView).Row[1].ToString(), (int)(allGoodsDG.SelectedItem as DataRowView).Row[2], (double)(allGoodsDG.SelectedItem as DataRowView).Row[3], (int)(allGoodsDG.SelectedItem as DataRowView).Row[4], (int)(allGoodsDG.SelectedItem as DataRowView).Row[5], (int)(allGoodsDG.SelectedItem as DataRowView).Row[6], (int)(allGoodsDG.SelectedItem as DataRowView).Row[7]));
            refreshData();
           
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(chosenGoodsDG.SelectedItem != null)
                orderedGoods.Remove(chosenGoodsDG.SelectedItem as Good);
            refreshData();
        }

        private void ExportAndSaveCheck_Btn_Click(object sender, RoutedEventArgs e)
        {
            var state = double.TryParse(priceTB.Text, out double moneyPayed);
            if (orderedGoods.Count > 0 && customerCMB.SelectedValue != null && state && moneyPayed >= double.Parse(fullPriceLabel.Content.ToString()))
            {
                new OrdersTableAdapter().InsertQuery(Convert.ToInt32(customerCMB.SelectedValue));
                var time = DateTime.Now.ToString();
                // Привязка пользователя к заказу
                foreach (var item in orderedGoods)
                {
                    new SavedChecksTableAdapter().InsertQuery((int)new OrdersTableAdapter().LastValueQ(),
                        new GoodsTableAdapter().ScalarQuery(item.name).Value, moneyPayed, time); // Привязка заказанных товаров и заказа к чеку
                }
                orderedGoods.Clear();
                refreshData();
            }
            else MessageBox.Show("INCORRECT FIELDS!");
            
        }

        private void refreshData()
        {
            chosenGoodsDG.ItemsSource = null;
            chosenGoodsDG.ItemsSource = orderedGoods;
            sum = 0;
            foreach (Good row in orderedGoods)
            {
                sum += row.pricePerOne;
            }
            fullPriceLabel.Content = sum.ToString();
        }
    }
}
