using Pandemic.Common.Models;
using Pandemic.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandemic.Prism.ViewModels
{
    public class DetailReportItemViewModel: ReportDetail
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _addDetailCommand;

        public DetailReportItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand ReportDetailCommand => _addDetailCommand ?? (_addDetailCommand = new DelegateCommand(ReportAsync));


        private async void ReportAsync()
        {
            var parameters = new NavigationParameters
            {
                { "report", this },

            };

            await _navigationService.NavigateAsync(nameof(AddDetailPage), parameters);
        }
    }
}
