using Pandemic.Common.Models;
using Pandemic.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandemic.Prism.ViewModels
{
     public class ReportItemViewModel : MyReportsResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectReportCommand;
        private DelegateCommand _addDetailCommand;

        public ReportItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectReportCommand => _selectReportCommand ?? (_selectReportCommand = new DelegateCommand(SelectReportAsync));

        private async void SelectReportAsync()
        {
            var parameters = new NavigationParameters
            {
                { "report", this }
            };

            await _navigationService.NavigateAsync(nameof(ModifyStatusPage), parameters);
        }
    }
}
