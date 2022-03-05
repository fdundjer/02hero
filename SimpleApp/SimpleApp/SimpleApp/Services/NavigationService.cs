using SimpleApp.Models;
using SimpleApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleApp.Services
{
    internal class NavigationService : INavigationService
    {
        public void NavigateToNoteEditor(Note note)
        {
            var vm = App.Locator.NoteEditorViewModel;
            vm.LoadNote(note);
            Application.Current
                 .MainPage
                 .Navigation
                 .PushModalAsync(new NoteView { BindingContext = vm });
        }

        public void GoBack()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public void NavigateToNewNoteEditor()
        {
            var vm = App.Locator.NoteEditorViewModel;
            Application.Current
                  .MainPage
                  .Navigation
                  .PushModalAsync(new NoteView { BindingContext = vm });
        }
    }
}
