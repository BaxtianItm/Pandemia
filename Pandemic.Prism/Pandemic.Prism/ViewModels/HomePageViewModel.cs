using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Navigation;

namespace Pandemic.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void AddReport()
        {


            await _navigationService.NavigateAsync("HomePage");
        }
    }
}
