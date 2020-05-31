using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Navigation;
using System.Collections.Generic;

namespace Pandemic.Prism.ViewModels
{
    public class DashboardPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private string _url;
        private List<Statistics> _data;

        public DashboardPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = Languages.Dashboard;
            IsEnabled = true;
            LoadReports();

        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public List<Statistics> Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
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

            Response response = await _apiService.Statistics<Statistics>(_url, "/api", "/Reports/Statistics");

            IsRunning = false;
            IsEnabled = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            Data = (List<Statistics>)response.Result;
        }
    }
}
