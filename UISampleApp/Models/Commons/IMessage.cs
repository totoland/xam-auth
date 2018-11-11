using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models.Commons
{
    public interface IMessage
    {
        void ShowMessage(string message);
        void ShowMessage(string message, int minSec);
        void Debug(string message);
        void Debug(string tag, string message);
    }
}
