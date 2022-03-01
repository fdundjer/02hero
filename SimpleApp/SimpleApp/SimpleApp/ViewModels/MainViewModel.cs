using SimpleApp.DataAccess;
using SimpleApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> _notesSource;
        private NoteViewModel _selectedNote;

        public MainViewModel()
        {
            AddNoteCommand = new Command(OnAddNoteCommand);
            SelectedNoteChangedCommand = new Command(OnSelectedNoteChangedCommand);
            LoadNotes();
        }


        public ObservableCollection<NoteViewModel> NotesSource
        {
            get { return _notesSource; }
            set 
            { 
                _notesSource = value; 
                OnPropertyChanged(nameof(NotesSource));
            }
        }

        public NoteViewModel SelectedNote
        {
            get
            {
                return _selectedNote;
            }
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        public ICommand AddNoteCommand { get; }

        public ICommand SelectedNoteChangedCommand { get; }

        private void LoadNotes()
        {
            var notesViewModel = new List<NoteViewModel>();
            var notes = App.NotesRepository.GetAllNotes();

            foreach(var note in notes)
            {
                notesViewModel.Add(new NoteViewModel(note, LoadNotes));
            }

            NotesSource = new ObservableCollection<NoteViewModel>(notesViewModel);
        }

        private void OnSelectedNoteChangedCommand()
        {
            if (SelectedNote != null)
            {
                Application.Current
                   .MainPage
                   .Navigation
                   .PushModalAsync(new NoteView { BindingContext = SelectedNote });
            }
           
            SelectedNote = null;
        }

        private void OnAddNoteCommand()
        {
            Application.Current
                .MainPage
                .Navigation
                .PushModalAsync(new NoteView { BindingContext = new NoteViewModel(() => LoadNotes()) });
        }
    }
}
