using Newtonsoft.Json;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pandemic.Prism.ViewModels
{
    public class ReportsHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private string _url;
        private UserResponse _user;
        private TokenResponse _token;
        private List<DetailReportItemViewModel> _report;
        private DelegateCommand _addReportCommand;


        public ReportsHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.CheckHistory;
            IsEnabled = true;
            LoadReports();
        }

        public DelegateCommand CreateReportCommand => _addReportCommand ?? (_addReportCommand = new DelegateCommand(CreateReport));

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public List<DetailReportItemViewModel> Report
        {
            get => _report;
            set => SetProperty(ref _report, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void LoadReports()
        {
            IsRunning = true;
            IsEnabled = false;

            _url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(_url);
            if (!connection)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            _user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            _token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            MyReportsRequest myReportsRequest = new MyReportsRequest
            {
                UserId = _user.Id
            };

            Response response = await _apiService.ListReportsAsync<ReportResponse>(_url, "/api", "/Reports/GetUserReports", myReportsRequest, "bearer", _token.Token);

            IsRunning = false;
            IsEnabled = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            List<MyReportsResponse> reports = (List<MyReportsResponse>)response.Result;
            Report = reports.Select(r => new DetailReportItemViewModel(_navigationService)
            {
                DateLocal = r.ReportDetails.Count() == 0? DateTime.Now :  r.ReportDetails.FirstOrDefault().DateLocal,
                Document = r.Document,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Id = r.Id,
                Observation = r.ReportDetails.Count() == 0 ? "" : r.ReportDetails.FirstOrDefault().Observation,
                Status = r.ReportDetails.Count() == 0 ? "": r.ReportDetails.FirstOrDefault().Status
            }).ToList();
        }

        private async void CreateReport()
        {
            await _navigationService.NavigateAsync("HomePage");
        }


    }
}
