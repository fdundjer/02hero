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
        private Guid _noteId;

        public NoteViewModel(Action action)
        {
            _action = action;

            IsNewNote = true;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
            DeleteNoteCommand = new Command(OnDeleteNoteCommand);
        }

        public NoteViewModel(Note note, Action action) : this(action)
        {
            _noteId = note.Id;

            IsNewNote = false;
            Title = note.Title;
            Description = note.Description;
        }

        public bool IsNewNote { get; }

        public ICommand SaveNoteCommand { get; set; }

        public ICommand DeleteNoteCommand { get; set; }

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

        private void OnDeleteNoteCommand()
        {
            //App.NotesRepository.DeleteNote(_noteId);
            Application.Current.MainPage.Navigation.PopModalAsync();

            _action?.Invoke();
        }

        private void OnSaveNoteCommand()
        {
            var note = new Note(Title, Description);
            //App.NotesRepository.AddNote(note);
            Application.Current.MainPage.Navigation.PopModalAsync();

            _action?.Invoke();
        }
    }
}
