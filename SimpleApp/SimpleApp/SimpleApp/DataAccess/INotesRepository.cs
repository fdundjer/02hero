using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.DataAccess
{
    internal interface INotesRepository
    {
        void AddNote(Note note);

        void DeleteNote(Guid id);

        IEnumerable<Note> GetAllNotes();
    }
}
