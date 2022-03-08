using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimpleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp.Droid.Services
{
    internal class Clipboard : IClipboard
    {
        public void SetText(string text)
        {
            throw new NotImplementedException();
        }
    }
}