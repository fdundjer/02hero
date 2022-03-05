using Microsoft.Extensions.DependencyInjection;
using SimpleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Services
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainViewModel MainViewModel 
            => _serviceProvider.GetService<MainViewModel>();

        public NoteEditorViewModel NoteEditorViewModel
            => _serviceProvider.GetService<NoteEditorViewModel>();
    }
}
