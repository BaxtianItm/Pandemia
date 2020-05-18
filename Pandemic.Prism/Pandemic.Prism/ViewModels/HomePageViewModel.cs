using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Pandemic.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        //private ReportResponse _report;
        private DelegateCommand _addReportCommand;

        public HomePageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.CreateReport;
            IsEnabled = true;
        }

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

        /*public ReportResponse Report
        {
            get => _report;
            set => SetProperty(ref _report, value);
        }*/

        private async void AddReport()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

        }

        private async Task<bool> ValidateDataAsync()
        {
            if (string.IsNullOrEmpty(/*Report.*/Document))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.DocumentError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(/*Report.*/FirstName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.FirstNameError, Languages.Accept);
                return false;
            }

            if (string.IsNullOrEmpty(/*Report.*/LastName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LastNameError, Languages.Accept);
                return false;
            }

            /* if (double.IsNaN(Report.TargetLatitude))
             {
                 await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.AddressError, Languages.Accept);
                 return false;
             }*/

            /* if (double.IsNaN(Report.TargetLongitude))
             {
                 await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.AddressError, Languages.Accept);
                 return false;
             }*/

            return true;
        }
    }
}
