using System;
using Newtonsoft.Json;

namespace SimpleApp.Models
{
    public class Note
    {
        [JsonConstructor]
        public Note(Guid id, string title, string description)
        {
            Id = id;
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException("Title can't be empty");
            }
            
            if (string.IsNullOrEmpty(description))
            {
                throw new InvalidOperationException(nameof(description));
            }

            Title = title;
            Description = description;
        }
        
        public Note(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException("Title can't be empty");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new InvalidOperationException(nameof(description));
            }
            
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }
        
        public Guid Id { get; }
        
        public string Title { get; }
        
        public string Description { get; }
    }
}
