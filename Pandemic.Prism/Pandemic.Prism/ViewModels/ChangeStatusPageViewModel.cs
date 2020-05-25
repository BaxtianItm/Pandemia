using Newtonsoft.Json;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Pandemic.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Prism.ViewModels
{
    public class ChangeStatusPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private Role _state;
        private bool _isRunning;
        private bool _isEnabled;
        private ObservableCollection<Role> _status;
        private DelegateCommand _modifyCommand;
        public ReportResponse Report;
        public List<ReportDetailsResponse> _reportDetails;
        private UserResponse _user;
        private TokenResponse _token;
        public int IdDetail;
 
        public ChangeStatusPageViewModel(INavigationService navigationService, IApiService apiService
            ) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.TitleModify;
            IsEnabled = true;
            Status = new ObservableCollection<Role>(CombosHelper.GetStatus());
        }

        public DelegateCommand ModifyCommand => _modifyCommand ?? (_modifyCommand = new DelegateCommand(UpdateStatusAsync));
         
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
        public List<ReportDetailsResponse> ReportDetails
        {
            get => _reportDetails;
            set => SetProperty(ref _reportDetails, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("report"))
            {
                Report = parameters.GetValue<ReportResponse>("report");
                ReportDetails = Report.ReportDetails;
            }
        }

        private async Task<bool> ValidateDataAsync()
        {
            if (Role == null)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.StatusError, Languages.Accept);
                return false;
            }

            return true;
        }

        private async void UpdateStatusAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            _user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            _token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);


            ChangeStatusRequest statusRequest = new ChangeStatusRequest
            {
                UserId = _user.Id,
                CultureInfo = Languages.Culture,
                StatusId= Role.Id,
                Id= ReportDetails.FirstOrDefault().Id

            };

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.ChangeStatusAsync(url, "/api", "/Reports/ChangeStatus", statusRequest, "bearer", token.Token);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            await App.Current.MainPage.DisplayAlert(Languages.Ok, Languages.StateUpdate, Languages.Accept);
            await _navigationService.NavigateAsync(nameof(AdminReportPage));
        }

    }
}
