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
        
        public MainViewModel()
        {
            AddNoteCommand = new Command(OnAddNoteCommand);
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

        public ICommand AddNoteCommand { get; }

        private void LoadNotes()
        {
            var notesViewModel = new List<NoteViewModel>();
            var notes = App.NotesRepository.GetAllNotes();

            foreach(var note in notes)
            {
                notesViewModel.Add(new NoteViewModel(note));
            }

            NotesSource = new ObservableCollection<NoteViewModel>(notesViewModel);
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
