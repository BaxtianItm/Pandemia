﻿using Pandemic.Common.Models;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pandemic.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isRemember;
        private string _password;
        private DelegateCommand _loginCommand;
        private DelegateCommand _registerCommand;
        private DelegateCommand _forgotPasswordCommand;

        public LoginPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.Login;
            IsEnabled = true;
            IsRemember = true;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public DelegateCommand ForgotPasswordCommand => _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ForgotPassword));

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public bool IsRemember
        {
            get => _isRemember;
            set => SetProperty(ref _isRemember, value);
        }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.EmailError, Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PasswordError, Languages.Accept);
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            TokenRequest request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };


            //Esto debe activarse al publicar las apis, está probado todo el token

            /* string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.UserIncorrect, Languages.Accept);
                Password = string.Empty;
                return;

            }

            TokenResponse token = (TokenResponse)response.Result;
            Response response2 = await _apiService.GetUserByEmailAsync(url, "api", "/Account/GetUserByEmail", "bearer", token.Token, Email);

            if (!response2.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.Error3, Languages.Accept);
                Password = string.Empty;
                return;
            }

            UserResponse User = (UserResponse)response2.Result;
            Settings.User = JsonConvert.SerializeObject(User);
            Settings.Token = JsonConvert.SerializeObject(token);
            Settings.IsRemembered = IsRemember;
            Settings.IsLogin = true;

            IsRunning = false;
            IsEnabled = true;

            await _navigationService.NavigateAsync("/PandemicMasterDetailPage/NavigationPage/HistoryPage");
            Password = string.Empty;
            */

        }

        private async void RegisterAsync()
        {
            await _navigationService.NavigateAsync("RegisterPage");

        }

        private async void ForgotPassword()
        {
            await _navigationService.NavigateAsync("RememberPasswordPage");
        }


    }
}
