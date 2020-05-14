﻿using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pandemic.Prism.ViewModels
{
    public class DashboardPageViewModel : ViewModelBase
    {
        public DashboardPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.Dashboard;

        }
    }
}
