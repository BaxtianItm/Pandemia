﻿using Pandemic.Prism.Helpers;
using Prism.Navigation;

namespace Pandemic.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.CreateReport;
        }
    }
}
