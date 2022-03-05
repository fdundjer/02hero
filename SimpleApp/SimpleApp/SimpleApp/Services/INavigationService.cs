using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Services
{
    internal interface INavigationService
    {
        void NavigateToNoteEditor(Note note);

        void NavigateToNewNoteEditor();

        void GoBack();
    }
}
