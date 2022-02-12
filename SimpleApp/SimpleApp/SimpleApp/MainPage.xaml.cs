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
        public MainPage()
        {
            InitializeComponent();
            FirstCheckbox.Text = First.IsChecked ? "Checked" : "Not checked";
            SecondCheckbox.Text = Second.IsChecked ? "Checked" : "Not checked";
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            FirstCheckbox.Text = e.Value ? "Checked" : "Not checked";
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                SecondCheckbox.Text = "Checked";
            }
            else
            {
                SecondCheckbox.Text = "Not checked";
            }
        }
    }
}
