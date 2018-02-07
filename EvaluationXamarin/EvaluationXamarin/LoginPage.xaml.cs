using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EvaluationXamarin
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.Title = "Login";
            this.btnLogin.Clicked += (sender, e) => Login();
            this.btnRegister.Clicked += (sender, e) => {
                var registerPage = new RegisterPage();
                this.Navigation.PushAsync(registerPage);
            };
        }

        private void Login()
        {
            if (this.entUsername.Text != String.Empty && this.entPassword.Text != String.Empty)
            {
                
                UserDAO.Login(this.entUsername.Text,
                                     this.entPassword.Text,
                                     (userpassCorrect) => {
                    if (userpassCorrect)
                    {
                        var movieListPage = new MovieListPage();
                        this.Navigation.PushAsync(movieListPage);
                    }
                }, (errorMessage) => {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        DisplayAlert("Error", errorMessage, "Ok", "Cancel");
                    }
                });
            }
        }
    }
}
