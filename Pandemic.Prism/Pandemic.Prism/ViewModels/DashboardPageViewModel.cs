using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
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
        private DelegateCommand _barGraphCommand;
        private DelegateCommand _cakeGraphCommand;

        public DashboardPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Dashboard;
            IsEnabled = true;

        }

        public DelegateCommand BarGraphCommand => _barGraphCommand ?? (_barGraphCommand = new DelegateCommand(BarGraphAsync));
        public DelegateCommand CakeGraphCommand => _cakeGraphCommand ?? (_cakeGraphCommand = new DelegateCommand(CakeGraphAsync));

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

        private async void BarGraphAsync()
        {
            await _navigationService.NavigateAsync("BarGraphPage");

        }
        private async void CakeGraphAsync()
        {
            await _navigationService.NavigateAsync("CakeGraphPage");

        }
    }
}
