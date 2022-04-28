using DemoApp.Models;
using DemoApp.Views;
using FluentValidation;
using System;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class LoginViewModel : NotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public LoginPage LoginPage { get; set; }

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => (string)_password;
            set => SetProperty(ref _password, value);
        }

        public LoginUser LoginUser { get; set; }


        public string validateMsg;
        public string ValidateMsg
        {
            get => validateMsg;
            set => SetProperty(ref validateMsg, value);
        }

        private readonly IValidator _validator;

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            _validator = new LoginUserValidator();
            LoginCommand = new Command(OnLoginClicked, IsNullData);
            this.PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool IsNullData(object arg)
        {
            LoginUser = new LoginUser();
            LoginUser.UserName = Username;
            LoginUser.Password = Password;

            var validaResult = _validator.Validate(new ValidationContext<LoginUser>(LoginUser));
            var result = validaResult.IsValid;
            // result = !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password);
            if (validaResult.Errors.Count > 0)
            {
                ValidateMsg = validaResult.Errors[0].ErrorMessage;
            }
            else
            {
                ValidateMsg = String.Empty;
            }

            return result;
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            if (LoginUser.UserName == "cool" && LoginUser.Password == "north")
            {
                ValidateMsg = "登录成功";
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                ValidateMsg = "登录失败";
            }

            // await Task.FromResult("");
        }
    }
}
