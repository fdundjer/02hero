using Microsoft.Extensions.DependencyInjection;
using SimpleApp.DataAccess;
using SimpleApp.Services;
using SimpleApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleApp
{
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;
        private static ViewModelLocator _viewLocator;

        public App()
        {
            InitializeComponent();
            SetupServices();

            MainPage = new MainPage { BindingContext = Locator.MainViewModel };
        }

        internal static ViewModelLocator Locator
        {
            get
            {
                if (_viewLocator is null)
                {
                    _viewLocator = new ViewModelLocator(_serviceProvider);
                }

                return _viewLocator;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void SetupServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<NoteViewModel>();
            serviceCollection.AddSingleton<INotesRepository, NotesRepository>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
