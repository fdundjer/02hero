using SimpleApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleApp
{
    public partial class MainPage : ContentPage
    {
        private int counter = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var mergedDictionaries
                = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();
            // Application.Current.UserAppTheme - tema ne telefonu
            // Application.Current.RequestedTheme - tema koja je promenjena
            if (counter % 2 == 0)
            {
                mergedDictionaries.Add(new Light());
            }
            else
            {
                mergedDictionaries.Add(new Dark());
            }

            counter++;
        }
    }
}
