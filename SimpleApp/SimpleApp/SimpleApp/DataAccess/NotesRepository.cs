using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp.DataAccess
{
    internal class NotesRepository
    {
        private List<Note> _notes = new List<Note>();

        public NotesRepository()
        {
            _notes.Add(new Note("This is short title",
                "This is short description"));
            _notes.Add(new Note("This is loooooooooooooooooooooooooooooooooooooooooooooooooooooooooong title",
                "This is lo lo lo lo lo lo lo lo lo lo lo lo lo lo lo lo ng description"));
        }

        public void AddNote(Note note)
        {
            _notes.Add(note);
        }

        public void DeleteNote(Guid id)
        {
            _notes = _notes.Where(note => note.Id != id).ToList();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return new List<Note>(_notes);
        }
    }
}
