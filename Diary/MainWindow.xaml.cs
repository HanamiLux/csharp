using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Diary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object selectedNoteButton;
       static List<Note> notesList = new List<Note>();
        List<Note> deserializedNotesList = MyJSON.Deserialization(notesList);

        public MainWindow()
        {
            InitializeComponent();
            read();
        }
        private void read()
        {
            stackPanelB.Children.Clear();
            notesList.Clear();
            List<Note> deserializedNotesList = MyJSON.Deserialization(notesList);
            DateTime selectedDate = DatePicker.SelectedDate ?? DateTime.Now;
            foreach (var note in deserializedNotesList)
            {
                Button but = new Button();
                but.Content = note.name;
                but.Name = note.name;
                if ((note.date.Year == selectedDate.Year) && (note.date.Month == selectedDate.Month) && (note.date.Day == selectedDate.Day))
                    but.Visibility = Visibility.Visible;
                else 
                    but.Visibility = Visibility.Collapsed;
                notesList.Add(note);
                stackPanelB.Children.Add(but);
                but.Click += (sender, EventArgs) => { Note_Click(sender, EventArgs, note); };
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MyJSON.Serialization(notesList);

        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string notename = nameTextBox.Text;
            Button but = new Button();
            notename = notename.Split(' ')[0];
            but.Content = notename;
            try
            {
                but.Name = notename;
            }
            catch (Exception)
            {
                notename = notename.Replace("'", "");
                foreach (var note in notesList) 
                    if (note.name == notename)
                    {
                        MessageBox.Show("Записка с таким именем уже есть");
                        return;
                    }
                    else
                        but.Name = notename.Split(' ')[0];
            }
            but.Name = notename;
            Note newNote = new Note(notename, descriptionTextBox.Text, DatePicker.SelectedDate ?? (DateTime.Now.AddDays(4)));
            notesList.Add(newNote);
            if (stackPanelB.Children.Count > 10 ) 
                MessageBox.Show("Notes overflow ( > 10)");
            else
            {
            stackPanelB.Children.Add(but);
                but.Click += (sender, EventArgs) => { Note_Click(sender, EventArgs, newNote); };
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            notesList = notesList.Where(x => x.name != (selectedNoteButton as Button)?.Name).ToList();
            stackPanelB.Children.Remove(selectedNoteButton as Button);
        } 
        private void Note_Click(object sender, RoutedEventArgs e, Note newNote)
        {
            nameTextBox.Text = (sender as Button).Content.ToString();
            descriptionTextBox.Text = newNote.description;
            selectedNoteButton = sender;
            Made.Content = "Made";
            bywho.Content = newNote.currentDate.Year + "/" + newNote.currentDate.Month + "/" + newNote.currentDate.Day;
            editBut.IsEnabled = true;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Made.Content = "Made by";
            bywho.Content = "HANAMIS";
            var unsavedList = notesList.ToList();
            read(); //notesList обнуляется и принимает значения через десериализацию
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
                        notesList = unsavedList;
                        }
            }

        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            ((DatePicker)sender).BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            bool IsIterate = false;
            (selectedNoteButton as Button).Content = nameTextBox.Text;
            foreach (var note in notesList)
            {
                if ((selectedNoteButton as Button).Name == note.name)
                {
                    note.description = descriptionTextBox.Text;
                    note.currentDate = DateTime.Now;

                    (selectedNoteButton as Button).Name = note.name = nameTextBox.Text.Split(' ')[0];
                    try
                    {
                        (selectedNoteButton as Button).Name = note.name;
                    }
                    catch (Exception)
                    {
                        note.name = note.name.Replace("'", "");
                        foreach (var addNote in notesList)
                            if (note.name == addNote.name)
                            {
                                MessageBox.Show("Записка с таким именем уже есть");
                                return;
                            }
                            else
                                (selectedNoteButton as Button).Name = note.name.Split(' ')[0];
                    }
                    (selectedNoteButton as Button).Name = note.name;
                    Note newNote = new Note(note.name, note.description, DatePicker.SelectedDate ?? (DateTime.Now.AddDays(4)));
                    notesList.Remove(note);
                    notesList.Add(newNote);
                IsIterate = true;
                }
                if (IsIterate)
                    break;
            }
                MyJSON.Serialization(notesList);
        }
    }

}
