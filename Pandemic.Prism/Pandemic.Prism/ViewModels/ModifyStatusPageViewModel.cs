using Newtonsoft.Json;
using Pandemic.Common.Helpers;
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
using System.Threading.Tasks;
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
        private DelegateCommand _modifyCommand;
        public ReportResponse Report;
        private List<ReportDetailsResponse> _reportDetails;

        private int Id;
        private string FirstName;
        private string LastName;
        private string Document;
        public ModifyStatusPageViewModel(INavigationService navigationService, IApiService apiService
            ) :base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.TitleModify;
            IsEnabled = true;
            Status = new ObservableCollection<Role>(CombosHelper.GetStatus());
        }
   
        //public DelegateCommand ModifyCommand => _modifyCommand ?? (_modifyCommand = new DelegateCommand(RegisterAsync));
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
                Id=Report.Id;
                FirstName = Report.FirstName;
                LastName = Report.LastName;
                Document = Report.Document;
                ReportDetails = Report.ReportDetails;
            
            }
        }

        private async Task<bool> ValidateDataAsync()
        {

            if (Status == null)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.StatusError, Languages.Accept);
                return false;
            }
          
            return true;
        }

        private async void SaveAsync()
        {
            bool isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            ChangeStatusRequest statusRequest = new ChangeStatusRequest
            {
                 

               // UserTypeId = User.UserType == UserType.User ? 1 : 2,
                CultureInfo = Languages.Culture,

            };

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.PutAsync(url, "/api", "/Reports/ChangeStatus", statusRequest, "bearer", token.Token);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

           
            await App.Current.MainPage.DisplayAlert(Languages.Ok, Languages.StateUpdate, Languages.Accept);
        }

    }
}

