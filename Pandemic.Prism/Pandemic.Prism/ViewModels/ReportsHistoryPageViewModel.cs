using Newtonsoft.Json;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;

namespace Pandemic.Prism.ViewModels
{
    public class ReportsHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private List<ReportResponse> _details;
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void LoadReports()
        {
            IsRunning = true;
            IsEnabled = false;

            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            MyReportsRequest request = new MyReportsRequest
            {
                UserId = user.Id
            };

            Response response = await _apiService.ListReportsAsync(url, "/api", "/Travel/GetTravel", request, "bearer", token.Token);

            IsRunning = false;
            IsEnabled = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }





        }

        private async void CreateReport()
        {
            await _navigationService.NavigateAsync("HomePage");
        }


    }
}
