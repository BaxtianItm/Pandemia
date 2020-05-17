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
    public class ReportsHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _addReportCommand;


        public ReportsHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {

            Title = Languages.CheckHistory;
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
