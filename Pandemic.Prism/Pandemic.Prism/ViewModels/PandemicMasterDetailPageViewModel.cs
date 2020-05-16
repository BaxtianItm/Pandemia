using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Pandemic.Common.Models;
using System.Collections.ObjectModel;
using Pandemic.Prism.Helpers;
using Pandemic.Common.Helpers;

namespace Pandemic.Prism.ViewModels
{
    public class PandemicMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public PandemicMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
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

                },
                new Menu
                {
                    Icon = "ic_admin",
                    PageName = "AdminReportPage",
                    Title = Languages.AdminReports,

                },
                new Menu
                {
                    Icon = "ic_dashboard",
                    PageName = "DashboardPage",
                    Title = Languages.Dashboard,
                },
                new Menu
                {
                    Icon = "ic_history",
                    PageName = "HistoryPage",
                    Title = Languages.CheckHistory,

                },
                new Menu
                {
                    Icon = "ic_usermodify",
                    PageName = "ModifyUserPage",
                    Title = Languages.ModifyTitle,

                },
                new Menu
                {
                    Icon = "ic_login",
                    PageName = "LoginPage",
                    Title = Settings.IsLogin ? Languages.Logout : Languages.Login
                }
            };


            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
