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
    public class ModifyStatusPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        public ModifyStatusPageViewModel(INavigationService navigationService, IApiService apiService
            ) :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.TitleModify;
        }
    }
}
