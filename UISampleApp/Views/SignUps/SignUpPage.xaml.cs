using Helpers.Settings;
using System;
using System.Collections.Generic;
using UISampleApp.Effects;
using UISampleApp.Logins;
using UISampleApp.Models;
using UISampleApp.Models.Commons;
using UISampleApp.Server;
using Xamarin.Forms;

namespace UISampleApp.Views.SignUps
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void HandleClickedLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void HandleRegister(object sender, EventArgs e)
        {
            var message = DependencyService.Get<IMessage>();

            var regService = DependencyService.Get<IRegisterService>();
            var model = new UserInfo
            {
                username = "user",
                password = "password"
            };

            ResponseCode resp = await regService.CreateUserAccount(model);

            if (resp.RespCode == "200")
            {
                message.ShowMessage("Register successfuly");
                Settings.TokenId = ((UserInfo)resp.Data).token;
            }
            else
            {
                message.ShowMessage("Fail with error code : "+ resp.RespCode);
            }
            
        }
    }

}
