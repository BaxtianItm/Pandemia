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
using System.Threading.Tasks;

namespace Pandemic.Prism.ViewModels
{
    public class AddDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        public int _reportId;
        private string _url;
        private UserResponse _user;
        private ReportResponse _report;
        private TokenResponse _token;
        private DelegateCommand _addDetailCommand;
        public AddDetailPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            IsEnabled = true;
            Title = Languages.ReportDetails;

        }
        public ReportDetail Report;
        public DelegateCommand AddDetailCommand => _addDetailCommand ?? (_addDetailCommand = new DelegateCommand(AddDetailstAsync));
        public string Observation { get; set; }
        public int idReport { get; set; }
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
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("report"))
            {
                Report = parameters.GetValue<ReportDetail>("report");
                RecivedId(Report.Id);
            }
        }
        public void RecivedId(int id)
        {
            idReport = id;
        }

        private async void AddDetailstAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

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

            ReportDetailRequest reportDetailRequest = new ReportDetailRequest
            {
                Observation = Observation,
                StatusId=2,
                UserId = _user.Id,
                CultureInfo = Languages.Culture,
                ReportId = idReport
            };

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.CreateReportDetailsAsync(url, "/api", "/Reports/AddDetails", reportDetailRequest, "bearer", token.Token);
            
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message,Languages.Accept);
                return;
            }
           
            await App.Current.MainPage.DisplayAlert(Languages.Ok, Languages.CreateDetails, Languages.Accept);
            await _navigationService.GoBackToRootAsync();
        }
        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(Observation))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ObservationError, Languages.Accept);
                return false;
            }
            return true;
        }

    }
}
