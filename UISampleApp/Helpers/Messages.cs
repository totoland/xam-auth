using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models.Commons;
using Xamarin.Forms;

namespace Helpers.Messages
{
    public class Messages
    {
        public static readonly IMessage Toast = DependencyService.Get<IMessage>();
    }
}
