using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;


namespace Pandemic.Prism.ViewModels
{
    public class ModifyStatusPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private Role _state;
        private bool _isRunning;
        private bool _isEnabled;
        private ObservableCollection<Role> _status;

        public ModifyStatusPageViewModel(INavigationService navigationService, IApiService apiService
            ) :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.TitleModify;
            IsEnabled = true;
            Status = new ObservableCollection<Role>(CombosHelper.GetStatus());
        }

        public DateTime dateSelect = DateTime.Today;
        public DateTime DataSelect
        {
            get
            {
                return dateSelect;
            }
            set
            {
                dateSelect = value;
            }

        }
        public Role Role
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public ObservableCollection<Role> Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
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


    }
}
