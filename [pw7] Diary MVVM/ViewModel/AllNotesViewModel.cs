using Diary.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.View;

namespace Diary.ViewModel
{
    class AllNotesViewModel : BindingHelper
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
        public AllNotesViewModel()
        {
            _allNotesList = new ObservableCollection<Note>(MyJSON.Deserialization(new List<Note>()));
            ExitCommand = new BindableCommand(_ => onRequestClose(this, new EventArgs()));
        }
    }
}
