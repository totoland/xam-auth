using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UISampleApp.Droid.Models.Commons;
using UISampleApp.Models.Commons;
using Xamarin.Forms;

[assembly:Dependency(typeof(MessageDroid))]
namespace UISampleApp.Droid.Models.Commons
{
    public class MessageDroid : IMessage
    {
        public void ShowMessage(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShowMessage(string message, int minSec)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Debug(string tag,string message)
        {
            System.Diagnostics.Debug.WriteLine(tag +" : "+ message);
        }
    }
}