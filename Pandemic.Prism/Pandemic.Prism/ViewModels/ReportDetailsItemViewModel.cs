using Pandemic.Common.Models;
using Pandemic.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandemic.Prism.ViewModels
{
    public class ReportDetailsItemViewModel : ReportDetailsResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTripCommand;
        private DelegateCommand _selectReportCommand;

        public ReportDetailsItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectReportDetailsCommand => _selectReportCommand ?? (_selectReportCommand = new DelegateCommand(SelectReportAsync));

        private async void SelectReportAsync()
        {
            var parameters = new NavigationParameters
            {
                { "reportDetails", this }
            };

            await _navigationService.NavigateAsync(nameof(ModifyStatusPage), parameters);
        }

    }
}
