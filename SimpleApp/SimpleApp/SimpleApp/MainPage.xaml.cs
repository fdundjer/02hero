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
        private const string ValidUsername = "02hero";
        private const string ValidPassword = "predavanje3";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            LoginLabel.IsVisible = true;

            if (PasswordEntry.Text == ValidPassword && UsernameEntry.Text == ValidUsername)
            {
                LoginLabel.Text = "Uspešan login";
            }
            else
            {
                LoginLabel.Text = "Neuspešan login";
            }    
        }
    }
}
