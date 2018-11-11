using Helpers.Messages;
using Helpers.Settings;
using System;
using System.Collections.Generic;
using UISampleApp.Effects;
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

        private void LoginClicked(object sender, EventArgs e)
        {
            Messages.message.ShowMessage(Settings.TokenId);
        }
    }
}
