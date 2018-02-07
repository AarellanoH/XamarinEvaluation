using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EvaluationXamarin
{
    public partial class RegisterPage : ContentPage
    {
        private UserModel userToRegister;
        public RegisterPage()
        {
            InitializeComponent();
            this.Title = "Register";

            this.btnRegister.Clicked += (sender, e) => Register();;

        }

        private void Register()
        {
            if (this.GetUserFromUI())
            {
                UserDAO.Register(this.userToRegister,
                                 (userResponse) => {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        DisplayAlert("Success", "You registered correctly " + userResponse.name, "Ok", "Cancel");
                    }

                                     this.Navigation.PopAsync();
                                 }, (errorMessage) => {
                                     DisplayAlert("Error", errorMessage, "Ok", "Cancel");
                                 });
            }
        }

        private bool GetUserFromUI()
        {
            if
                (
                this.entName.Text == String.Empty ||
                this.entUsername.Text == String.Empty ||
                this.entPhone.Text == String.Empty ||
                this.entPassword.Text == String.Empty ||
                this.entPasswordConfirmation.Text == String.Empty
                )
            {
                if(Device.RuntimePlatform == Device.iOS){
                    DisplayAlert("Error", "You did not fill all the fields. Please try" +
                             " again.", "Ok", "Cancel");
                }
                return false;
            }
            else if (this.entPassword.Text != this.entPasswordConfirmation.Text)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    DisplayAlert("Error", "Password and confirmation do not match." +
                             " Please try again.", "Ok", "Cancel"); 
                }

                return false;
            }
            else
            {
                this.userToRegister = new UserModel(this.entName.Text, this.entUsername.Text,
                                               int.Parse(this.entPhone.Text), this.entPassword.Text, this.entPasswordConfirmation.Text);
                return true;
            }

        }

    }
}
