﻿using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Prism.ViewModels
{
    public class RememberPasswordPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IRegexHelper _regexHelper;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _recoverCommand;

        public RememberPasswordPageViewModel(
            INavigationService navigationService,
            IRegexHelper regexHelper,
            IApiService apiService) : base(navigationService)

        {
            _navigationService = navigationService;
            _apiService = apiService;
            _regexHelper = regexHelper;
            Title = Languages.PasswordRecover;
            IsEnabled = true;
        }

        public DelegateCommand RecoverCommand => _recoverCommand ?? (_recoverCommand = new DelegateCommand(Recover));

        public string Email { get; set; }

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

        private async void Recover()
        { 
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

              var request = new EmailRequest
              {
                  Email = Email,
                  CultureInfo = Languages.Culture
                  
              };

              var url = App.Current.Resources["UrlAPI"].ToString();
              var response = await _apiService.RecoverPasswordAsync(
                  url,
                  "api",
                  "/Account/RecoverPassword",
                  request);

              IsRunning = false;
              IsEnabled = true;

              if (!response.IsSuccess)
              {
                  await App.Current.MainPage.DisplayAlert(
                      Languages.Error,
                      response.Message,
                      Languages.Accept);
                  return;
              }

              await App.Current.MainPage.DisplayAlert(
                  "Ok",
                  response.Message,
                  Languages.Accept);
              await _navigationService.GoBackAsync();
          }

          private async Task<bool> ValidateData()
          {
              if (string.IsNullOrEmpty(Email) || !_regexHelper.IsValidEmail(Email))
              {
                  await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ValidEmail, Languages.Accept);
                  return false;
              }

              return true;
         
        }
        }
}
