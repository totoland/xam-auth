using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UISampleApp.Droid.Models.Commons;
using UISampleApp.Models.Commons;
using Xamarin.Forms;

[assembly:Dependency(typeof(MessageIOS))]
namespace UISampleApp.Droid.Models.Commons
{
    public class MessageIOS : IMessage
    {
        public void ShowMessage(string message)
        {
           //TODO
        }

        public void ShowMessage(string message, int minSec)
        {
            //TODO
        }

        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Debug(string tag, string message)
        {
            System.Diagnostics.Debug.WriteLine(tag + " : " + message);
        }
    }
}