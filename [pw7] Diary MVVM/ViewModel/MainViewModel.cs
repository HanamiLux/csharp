using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Diary.ViewModel.Helpers;
using System.Net.Mail;
using System.Collections.ObjectModel;
using Diary.View;

namespace Diary.ViewModel
{
    class MainViewModel : BindingHelper
    {
        #region Properties and vars

        static List<Note> notesList = new List<Note>();
        List<Note> deserializedNotesList = MyJSON.Deserialization(notesList);
        private ObservableCollection<Note> _stackPanelB = new  ObservableCollection<Note>();
        private DateTime _selectedDate = DateTime.Now;
        private Note _selectedNote = new Note();

        
        public ObservableCollection<Note> stackPanelB
        {
            get { return _stackPanelB; }
            set 
            { 
                _stackPanelB = value;
                OnPropertyChanged();
            }
        }
        public Note SelectedNote
        {
            get 
            {  
                if(_selectedNote == null)
                    _selectedNote = new Note();
                return _selectedNote; 
            }
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
            }
        }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public BindableCommand AddCommand { get; set; }
        public BindableCommand RemoveCommand { get; set; }
        public BindableCommand ChangeDateCommand { get; set; }
        public BindableCommand SaveCommand { get; set; }
        public BindableCommand ToAllNotesCommand { get; set; }
        public BindableCommand ToExpiredNotesCommand { get; set; }

        #endregion
        public MainViewModel()
        {
            AddCommand = new BindableCommand(_ => Create_Click());
            RemoveCommand = new BindableCommand(_ => Remove_Click());
            SaveCommand = new BindableCommand(_ => Save_Click());
            ChangeDateCommand = new BindableCommand(_ => DatePicker_SelectedDateChanged());
            try
            {
                ToAllNotesCommand = new BindableCommand(_ => new AllNotesWindow().Show());
                ToExpiredNotesCommand = new BindableCommand(_ => new ExpiredNotesWindow().Show());
            }
            catch (Exception)
            {
                ToAllNotesCommand = new BindableCommand(_ => new AllNotesWindow().Show());
                ToExpiredNotesCommand = new BindableCommand(_ => new ExpiredNotesWindow().Show());
            }
            read();
        }
        private void read()
        {
            stackPanelB.Clear();
            notesList.Clear();
            List<Note> deserializedNotesList = MyJSON.Deserialization(notesList);
            foreach (var note in deserializedNotesList)
            {
                notesList.Add(note);
                if ((note.date.Year == SelectedDate.Year) && (note.date.Month == SelectedDate.Month) && (note.date.Day == SelectedDate.Day))
                    stackPanelB.Add(note);
            }
        }
        private void Save_Click()
        {
            MyJSON.Serialization(notesList);
        }


        private void Create_Click()
        {
            string notename;
            try
            {
                
                notename = SelectedNote.name == ""? "Note" : SelectedNote.name;
            }
            catch (Exception) 
            {
                MessageBox.Show("Incorrect fields");
                return;
            }
            notename = notename.Split(' ')[0];
                foreach (var note in notesList)
                    if (note.name == notename)
                    {
                        MessageBox.Show("Записка с таким именем уже есть");
                        return;
                    }
            var id = new Guid().ToString();
            Note newNote = new Note(id, notename, SelectedNote.description, SelectedDate);
            notesList.Add(newNote);
            if (stackPanelB.Count > 10)
                MessageBox.Show("Notes overflow ( > 10)");
            else
                stackPanelB.Add(newNote);
        }


        private void Remove_Click()
        {
            notesList = notesList.Where(x => x.name != SelectedNote.name).ToList();
            _stackPanelB.Remove(_selectedNote);//fix later
        }
        private void DatePicker_SelectedDateChanged()
        {
            var unsavedList = notesList.ToList();
            read(); //notesList обнуляется и принимает значения через десериализацию
            //Проверка на альцгеймер у  пользователя:
            if (unsavedList.Count != notesList.Count)
            {
                string messageBoxText = "Do you want to save changes?";
                string caption = "Save?";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                    if (notesList.Count > unsavedList.Count)
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
    }
}
