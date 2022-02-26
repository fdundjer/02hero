using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    internal class NoteViewModel : BaseViewModel
    {
        private readonly Action _action;
        private string _title;
        private string _description;

        public NoteViewModel(Action action)
        {
            _action = action;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
        }

        public NoteViewModel(Note note)
        {
            Title = note.Title;
            Description = note.Description;
            SaveNoteCommand = new Command(OnSaveNoteCommand);

        }

        public ICommand SaveNoteCommand { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private void OnSaveNoteCommand()
        {
            var note = new Note(Title, Description);
            App.NotesRepository.AddNote(note);
            Application.Current.MainPage.Navigation.PopModalAsync();

            _action?.Invoke();
        }
    }
}
