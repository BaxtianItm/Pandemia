using Newtonsoft.Json;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pandemic.Prism.ViewModels
{
    public class AdminReportPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _url;
        private UserResponse _user;
        private TokenResponse _token;
        private List<ReportItemViewModel> _report;
        
        private bool _isRunning;
        private bool _isEnabled;
        public AdminReportPageViewModel(INavigationService navigationService, IApiService apiService
            ) :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            IsEnabled = true;
            Title = Languages.AdminReports;
            ListReportAsync();
        }

        public List<ReportItemViewModel> Report
        {
            get => _report;
            set => SetProperty(ref _report, value);
        }

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

        private async void ListReportAsync()
        {

            IsRunning = true;
            IsEnabled = false;

            _url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(_url);
            if (!connection)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConnectionError,
                    Languages.Accept);
                return;
            }

            _user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            _token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);


            MyReportsRequest myReportsRequest = new MyReportsRequest
            {
                UserId = _user.Id
            };


            Response response = await _apiService.ListReportsAsync<ReportResponse>(_url, "/api", "/Reports/GetMyReports", myReportsRequest, "bearer", _token.Token);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            
            List<MyReportsResponse> reports = (List<MyReportsResponse>)response.Result;
            Report = reports.Select(r => new ReportItemViewModel(_navigationService)
            { 
                Document=r.Document,
                Id = r.Id,
                FirstName=r.FirstName,
                LastName=r.LastName,
                SourceLatitude=r.SourceLatitude,
                TargetLongitude=r.TargetLongitude,
                ReportDetails = r.ReportDetails.Select(rd => new ReportDetailsResponse
                {
                    Id = rd.Id,
                    Date=rd.Date,
                    Observation=rd.Observation,
                    Status=rd.Status

                }).ToList()
            }).ToList();
         
        }

    }
}
