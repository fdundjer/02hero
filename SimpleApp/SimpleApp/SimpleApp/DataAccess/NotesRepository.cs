using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace SimpleApp.DataAccess
{
    public class NotesRepository : INotesRepository
    {       
        private List<Note> _notes = new List<Note>();
        private const string FileName = "notes.txt"; 

        public NotesRepository()
        {
            LoadNotes();
        }

        public void AddNote(Note note)
        {
            _notes.Add(note);
            Save();
        }

        public void DeleteNote(Guid id)
        {
            _notes = _notes.Where(n => n.Id != id).ToList();
            Save();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _notes.ToList();
        }

        private void LoadNotes()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, FileName);
            if (!File.Exists(path))
            {
                return;
            }
            
            var data = File.ReadAllText(path);
            _notes = JsonConvert.DeserializeObject<List<Note>>(data);
        }
        
        private void Save()
        {
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), JsonConvert.SerializeObject(_notes));
        }
    }
}
