﻿using Diary.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.View;
using System.Collections.ObjectModel;

namespace Diary.ViewModel
{
    class ExpiredNotesViewModel : BindingHelper
    {
        #region vars and props
        private ObservableCollection<Note> _allNotesList = new ObservableCollection<Note>();
        public event EventHandler onRequestClose;
        public ObservableCollection<Note> AllNotes
        {
            get { return _allNotesList; }
            set
            {
                _allNotesList = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region commands
        public BindableCommand ExitCommand { get; set; }
        #endregion
        public ExpiredNotesViewModel()
        {
            _allNotesList = new ObservableCollection<Note>(MyJSON.Deserialization(new List<Note>()).Where(i => i.date.Date < DateTime.Now.Date).ToList());
            ExitCommand = new BindableCommand(_ => onRequestClose(this, new EventArgs()));
        }
    }
}