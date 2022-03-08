using SimpleApp.DataAccess;
using SimpleApp.Models;
using SimpleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    internal class NoteEditorViewModel : BaseViewModel
    {
        private readonly INotesRepository _notesRepository;
        private readonly INavigationService _navigationService;
        private readonly IClipboard _clipboardService;
        private string _title;
        private string _description;
        private Guid _noteId;

        public NoteEditorViewModel(INotesRepository notesRepository, 
            INavigationService navigationService, 
            IClipboard clipboardService)
        {
            _notesRepository = notesRepository;
            _navigationService = navigationService;
            _clipboardService = clipboardService;

            IsNewNote = true;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
            DeleteNoteCommand = new Command(OnDeleteNoteCommand);
            CopyNoteCommand = new Command(OnCopyNoteCommand);
        }

        public bool IsNewNote { get; set; }

        public ICommand CopyNoteCommand { get; set; }

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

        public void LoadNote(Note note)
        {
            _noteId = note.Id;

            IsNewNote = false;
            Title = note.Title;
            Description = note.Description;
        }

        private void OnCopyNoteCommand()
        {
            _clipboardService.SetText($"{Title}{Environment.NewLine}{Description}");
        }

        private void OnDeleteNoteCommand()
        {
            _notesRepository.DeleteNote(_noteId);
            _navigationService.GoBack();
        }

        private void OnSaveNoteCommand()
        {
            var note = new Note(Title, Description);
            _notesRepository.AddNote(note);
            _navigationService.GoBack();
        }
    }
}
