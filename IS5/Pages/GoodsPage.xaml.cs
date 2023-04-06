using IS5.MyDBDataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        string pattern = @"^[A-z]\w*$";
        public GoodsPage()
        {
            InitializeComponent();
            RefreshData();
            builderCMB.ItemsSource = new BuildersTableAdapter().GetData();
            realtorCMB.ItemsSource = new RealtorsTableAdapter().GetData();
            tierCMB.ItemsSource = new TiersTableAdapter().GetData();
            typeCMB.ItemsSource = new TypeNamesTableAdapter().GetData();
            typeCMB.DisplayMemberPath = "typeName";
            builderCMB.DisplayMemberPath = "builder";
            realtorCMB.DisplayMemberPath = "realtor";
            tierCMB.DisplayMemberPath = "tier";
            builderCMB.SelectedValuePath = "builderId";
            realtorCMB.SelectedValuePath = "realtorId";
            tierCMB.SelectedValuePath = "tierId";
            typeCMB.SelectedValuePath = "typeId";
        }

        private void ImportData_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Good> importedData = MyJSON.Deserialization<List<Good>>();
            foreach (var item in importedData)
            {
                if(double.TryParse(item.pricePerOne.ToString(), out double price) && int.TryParse(item.typeId.ToString(), out int typeId) && int.TryParse(item.amount.ToString(), out int amount) && int.TryParse(item.tierId.ToString(), out int tierId) && int.TryParse(item.realtorId.ToString(), out int realtorId) && int.TryParse(item.builderId.ToString(), out int builderId) &&
                    price > 0 && amount > 0 && typeId > 0 && tierId > 0 && realtorId > 0 && builderId > 0)
                new GoodsTableAdapter().InsertQuery(item.name, item.amount, item.pricePerOne, item.typeId, item.tierId, item.realtorId, item.builderId);
            }
            RefreshData();
        }

        private void goodsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (goodsDG.SelectedItem != null)
            {
                nameTB.Text = (goodsDG.SelectedItem as DataRowView).Row[1].ToString();
                amountTB.Text = (goodsDG.SelectedItem as DataRowView).Row[2].ToString();
                priceTB.Text = (goodsDG.SelectedItem as DataRowView).Row[3].ToString();
                typeCMB.SelectedValue = (goodsDG.SelectedItem as DataRowView).Row[4];
                tierCMB.SelectedValue = (goodsDG.SelectedItem as DataRowView).Row[5];
                realtorCMB.SelectedValue = (goodsDG.SelectedItem as DataRowView).Row[6];
                builderCMB.SelectedValue = (goodsDG.SelectedItem as DataRowView).Row[7];
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTB.Text, out int amount) && double.TryParse(priceTB.Text, out double price) && price > 0 && amount > 0)
            {
                if (nameTB.Text != "" && builderCMB.SelectedValue != null && realtorCMB.SelectedValue != null && tierCMB.SelectedValue != null && typeCMB.SelectedValue != null && Regex.IsMatch(nameTB.Text, pattern, RegexOptions.IgnoreCase))
                    new GoodsTableAdapter().InsertQuery(nameTB.Text, amount, price, Convert.ToInt32(typeCMB.SelectedValue), Convert.ToInt32(tierCMB.SelectedValue), Convert.ToInt32(realtorCMB.SelectedValue), Convert.ToInt32(builderCMB.SelectedValue));
                else MessageBox.Show("Проверка moment*");
            }
            else MessageBox.Show("Incorrect числовые values");
            RefreshData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTB.Text, out int amount) && double.TryParse(priceTB.Text, out double price) && price > 0 && amount > 0 && goodsDG.SelectedItem != null)
            {
                if (nameTB.Text != "" && builderCMB.SelectedValue != null && realtorCMB.SelectedValue != null && tierCMB.SelectedValue != null && typeCMB.SelectedValue != null && Regex.IsMatch(nameTB.Text, pattern, RegexOptions.IgnoreCase) )
                    new GoodsTableAdapter().UpdateQuery(nameTB.Text, amount, price, Convert.ToInt32(typeCMB.SelectedValue), Convert.ToInt32(tierCMB.SelectedValue), Convert.ToInt32(realtorCMB.SelectedValue), Convert.ToInt32(builderCMB.SelectedValue), (int)(goodsDG.SelectedItem as DataRowView).Row[0]);
                else MessageBox.Show("Проверка moment*");
            }
            else MessageBox.Show("Incorrect числовые values или не выбрана запись");
            RefreshData();
        }

        private void Remove_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (goodsDG.SelectedItem != null)
                new GoodsTableAdapter().DeleteQuery((int)(goodsDG.SelectedItem as DataRowView).Row[0]);
            RefreshData();
        }
        private void RefreshData()
        {
            goodsDG.ItemsSource = null;
            goodsDG.ItemsSource = new GoodsTableAdapter().GetData();
        }
    }
}
