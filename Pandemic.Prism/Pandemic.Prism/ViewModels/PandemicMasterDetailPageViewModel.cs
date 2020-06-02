using Newtonsoft.Json;
using Pandemic.Common.Enums;
using Pandemic.Common.Helpers;
using Pandemic.Common.Models;
using Pandemic.Common.Services;
using Pandemic.Prism.Helpers;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pandemic.Prism.ViewModels
{
    public class PandemicMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private static PandemicMasterDetailPageViewModel _instance;
        private UserResponse _user;
        public PandemicMasterDetailPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            _apiService = apiService;
            LoadUser();
            LoadMenus();
        }
        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }

        public static PandemicMasterDetailPageViewModel GetInstance()
        {
            return _instance;
        }
        public async void ReloadUser()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                return;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            EmailRequest emailRequest = new EmailRequest
            {
                CultureInfo = Languages.Culture,
                Email = user.Email
            };

            Response response = await _apiService.GetUserByEmail(url, "api", "/Account/GetUserByEmail", "bearer", token.Token, emailRequest);
            UserResponse userResponse = (UserResponse)response.Result;
            Settings.User = JsonConvert.SerializeObject(userResponse);
            LoadUser();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
                {
                    new Menu
                    {
                        Icon = "ic_report",
                        PageName = "HomePage",
                        Title = Languages.CreateReport,
                        IsLoginRequired = true,
                        IsAdmin = false
                    },
                    new Menu
                    {
                        Icon = "ic_admin",
                        PageName = "AdminReportPage",
                        Title = Languages.AdminReports,
                        IsLoginRequired = true,
                        IsAdmin =  true
                    },
                    new Menu
                    {
                        Icon = "ic_dashboard",
                        PageName = "DashboardPage",
                        Title = Languages.Dashboard,
                        IsAdmin = false
                    },
                    new Menu
                    {
                        Icon = "ic_history",
                        PageName = "HistoryPage",
                        Title = Languages.CheckHistory,
                        IsLoginRequired = true,
                        IsAdmin = false

                    },
                    new Menu
                    {
                        Icon = "ic_usermodify",
                        PageName = "ModifyUserPage",
                        Title = Languages.ModifyTitle,
                        IsLoginRequired = true,
                        IsAdmin = false

                    },
                    new Menu
                    {
                        Icon = "ic_login",
                        PageName = "LoginPage",
                        Title = Settings.IsLogin ? Languages.Logout : Languages.Login,
                        IsAdmin = false
                    }
                };
            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
           

            if (Settings.IsLogin)
            {
                bool isUser = false;

                if (user.UserType == UserType.User)
                {
                    isUser = true;
                }
                if (isUser)
                {
                    Menus = new ObservableCollection<MenuItemViewModel>(
                       menus.Where(m => m.IsAdmin == false).Select(m => new MenuItemViewModel(_navigationService)
                       {
                           Icon = m.Icon,
                           PageName = m.PageName,
                           Title = m.Title,
                           IsLoginRequired = m.IsLoginRequired
                       }).ToList());
                }
                else
                {
                    Menus = new ObservableCollection<MenuItemViewModel>(
                        menus.Select(m => new MenuItemViewModel(_navigationService)
                        {
                            Icon = m.Icon,
                            PageName = m.PageName,
                            Title = m.Title,
                            IsLoginRequired = m.IsLoginRequired
                        }).ToList());
                }
            }
            else
            {
                Menus = new ObservableCollection<MenuItemViewModel>(
                   menus.Where(r => r.IsLoginRequired != true).Select(m => new MenuItemViewModel(_navigationService)
                   {
                       Icon = m.Icon,
                       PageName = m.PageName,
                       Title = m.Title,
                       IsLoginRequired = m.IsLoginRequired
                   }).ToList());
            }
        }
    }
}
