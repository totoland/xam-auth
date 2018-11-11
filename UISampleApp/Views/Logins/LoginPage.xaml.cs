using Helpers.Messages;
using Helpers.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UISampleApp.Effects;
using UISampleApp.Models;
using UISampleApp.Models.Commons;
using UISampleApp.Server;
using UISampleApp.Views.CheckIn;
using UISampleApp.Views.ForgotPasswords;
using UISampleApp.Views.SignUps;
using Xamarin.Forms;

namespace UISampleApp.Logins
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }

        async void HandleClickedForgotPassword(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPassword());
        }

        private async void HandleLogin(object sender, EventArgs e)
        {
            var message = DependencyService.Get<IMessage>();

            var regService = DependencyService.Get<IRegisterService>();
            var model = new UserInfo
            {
                username = Email.Text,
                password = Password.Text
            };

            ResponseCode resp = await regService.Login(model);

            if (resp.RespCode == ResponseCode.SUCCESS)
            {
                message.ShowMessage("Login successfuly");
                Settings.TokenId = ((UserInfo)resp.Data).token;
                await Navigation.PushModalAsync(new CheckIn());
            }
            else
            {
                message.ShowMessage(resp.RespCode);
            }

        }
    }
}
