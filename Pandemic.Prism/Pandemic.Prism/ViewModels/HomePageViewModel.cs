using Newtonsoft.Json;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Pandemic.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Pandemic.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IGeolocatorService _geolocatorService;
        private Position _position;
        private string _url;
        private string _source;
        private string _buttonLabel;
        private bool _isRunning;
        private bool _isEnabled;
        private UserResponse _user;
        private TokenResponse _token;
        private ReportResponse _report;
        private DelegateCommand _addReportCommand;
        private DelegateCommand _getAddressCommand;

        public HomePageViewModel(
            INavigationService navigationService,
            IApiService apiService, 
            IGeolocatorService geolocatorService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _geolocatorService = geolocatorService;
            Title = Languages.CreateReport;
            IsEnabled = true;
            LoadSourceAsync();
        }
        public DelegateCommand GetAddressCommand => _getAddressCommand ?? (_getAddressCommand = new DelegateCommand(LoadSourceAsync));
        public DelegateCommand AddReportCommand => _addReportCommand ?? (_addReportCommand = new DelegateCommand(AddReport));

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

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

       public ReportResponse Report
        {
            get => _report;
            set => SetProperty(ref _report, value);
        }
        public string Source
        {
            get => _buttonLabel;
            set => SetProperty(ref _buttonLabel, value);
        }
        public string ButtonLabel
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

   
        private async void AddReport()
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


            ReportRequest reportRequest = new ReportRequest
            {
                FirstName =  FirstName,
                LastName =  LastName,
                Document = Document,
                Address = Source,
                UserId = _user.Id,
                CultureInfo = Languages.Culture

            };

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.CreateReportAsync(url, "/api", "/Reports", reportRequest, "bearer", token.Token);
           
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }
            await App.Current.MainPage.DisplayAlert(Languages.Ok, Languages.ReportCreated, Languages.Accept);
            _report = (ReportResponse)response.Result;
            AddDetailAsync(_report);
        }
        private async void AddDetailAsync(ReportResponse report)
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "report", report },
            };

            await _navigationService.NavigateAsync(nameof(AddDetailPage), parameters);
        }
        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(Document))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.DocumentError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.FirstNameError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LastNameError, Languages.Accept);
                return false;
            }

             if (string.IsNullOrEmpty(Source))
             {
                 await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.AddressError, Languages.Accept);
                 return false;
             }

            return true;
        }
        private async void LoadSourceAsync()
        {
            IsEnabled = false;
            await _geolocatorService.GetLocationAsync();

            if (_geolocatorService.Latitude == 0 && _geolocatorService.Longitude == 0)
            {
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.GeolocationError, Languages.Accept);
                await _navigationService.GoBackAsync();
                return;
            }

            _position = new Position(_geolocatorService.Latitude, _geolocatorService.Longitude);
            Geocoder geoCoder = new Geocoder();
            IEnumerable<string> sources = await geoCoder.GetAddressesForPositionAsync(_position);
            List<string> addresses = new List<string>(sources);

            if (addresses.Count > 1)
            {
                Source = addresses[0];
            }

            IsEnabled = true;
        }

    }
}
