using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Budget;
using System.Runtime.InteropServices;

namespace Diary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       static List<Note> notesList = new List<Note>();
        static List<Note> todayList = new List<Note>();
        List<string> notesTypes = new List<string>{"New type"};

        public MainWindow()
        {
            InitializeComponent();
            read();
            table.IsReadOnly = true;
            RefreshSummary();
            editBut.IsEnabled = false;
        }
        private void read()
        {
            allTypesBox.ItemsSource = null;
            allTypesBox.ItemsSource = notesTypes;
            todayList.Clear();
            table.ItemsSource = null;
            notesList = MyJSON.Deserialization(notesList);
            DateTime selectedDate = DatePicker.SelectedDate ??DateTime.Now;
            todayList = notesList.Where(x => x.date.Day == selectedDate.Day && x.date.Month == selectedDate.Month && x.date.Year == selectedDate.Year).ToList();
            table.ItemsSource = todayList;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MyJSON.Serialization(notesList);
            RefreshSummary();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            bool income = false;
            if (int.TryParse(moneyTextBox.Text, out int amount) && nameTextBox.Text != string.Empty && allTypesBox.SelectedItem as string != string.Empty)
            {
                if (amount < 0)
                {
                    income = false;
                    amount = Math.Abs(amount);
                }
                else if (amount == 0)
                {
                    MessageBox.Show("Money value error");
                    return;
                }
                else
                    income = true;
                var note = new Note(nameTextBox.Text, allTypesBox.SelectedItem as string, amount, (DateTime)DatePicker.SelectedDate);
                note.isIncome = income;
                todayList.Add(note);
                notesList.Add(note);
                table.ItemsSource = null;
                table.ItemsSource = todayList;
            }
            else
                MessageBox.Show("Incorrect values");
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            notesList = notesList.Where(x => x.count != (table.SelectedItem as Note)?.count).ToList();
            todayList = notesList.Where(x => x.date.Day == DatePicker.SelectedDate.Value.Day && x.date.Month == DatePicker.SelectedDate.Value.Month && x.date.Year == DatePicker.SelectedDate.Value.Year).ToList();
            table.ItemsSource = null;
            table.ItemsSource = todayList;
        } 

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            var unsavedList = notesList.ToList();
            read(); //todayList обнуляется и принимает значения через десериализацию
            if (unsavedList.Count != notesList.Count)
            {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Save?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                        if(notesList.Count > unsavedList.Count) 
                        { 
                            MyJSON.Serialization(unsavedList);
                        }
                        else
                        {
                            MyJSON.Serialization(unsavedList);
                        }
                            notesList = unsavedList;
            }
        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            (table.SelectedItem as Note).name = nameTextBox.Text;
            if(int.TryParse(moneyTextBox.Text, out int value))
            (table.SelectedItem as Note).money = value;
            (table.SelectedItem as Note).type = allTypesBox.Text;

         /*   notesList = notesList.Where(x => x.count != (table.SelectedItem as Note)?.count).ToList();*/
            MyJSON.Serialization(notesList);
            RefreshSummary();
            table.ItemsSource = null;
            table.ItemsSource = todayList;

        }

        private void allTypesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ( allTypesBox.SelectedItem as string == "New type")
                NewTypeCreate();
        }

        private void NewTypeCreate()
        {
            NewTypeWindow window = new NewTypeWindow();
            window.ShowDialog();

            if (window.isSaveType)
            {
                foreach (var type in notesTypes)
                {
                    if (window.newTyped == type)
                        return;
                }
                notesTypes.Add(window.newTyped);
            }

            allTypesBox.ItemsSource = null;
            allTypesBox.ItemsSource = notesTypes;
            allTypesBox.Text = window.newTyped;
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editBut.IsEnabled= true;
            if (table.SelectedItem as Note == null)
                return;
           nameTextBox.Text = (table.SelectedItem as Note).name;
            foreach (var type in notesTypes)
            {
                if ((table.SelectedItem as Note).type == type)
                {
                    allTypesBox.Text = type;
                    moneyTextBox.Text = (table.SelectedItem as Note).money.ToString();
                    return;
                }
            }
            notesTypes.Add((table.SelectedItem as Note).type);
            moneyTextBox.Text = (table.SelectedItem as Note).money.ToString();
            allTypesBox.ItemsSource = null;
            allTypesBox.ItemsSource = notesTypes;
            allTypesBox.Text = (table.SelectedItem as Note).type;

        }

        private void RefreshSummary()
        {
            Note.summary = 0;
            foreach (Note note in notesList)
            {
                Note.summary += note.isIncome ? note.money : -note.money;
            }
            Moneybox.Content = Note.summary;
        }
    }

}
