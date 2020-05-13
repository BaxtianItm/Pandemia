using Prism;
using Prism.Ioc;
using Pandemic.Prism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pandemic.Prism.Views;
using Syncfusion.Licensing;
using Newtonsoft.Json;
using Pandemic.Common.Models;
using Pandemic.Common.Helpers;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Pandemic.Prism
{
    public partial class App
    {
        
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjU2MTI1QDMxMzgyZTMxMmUzMEd4MUtKekVnc1B1QjFVOWVCM2lzdmZRWWpCbThObUIvVUJzZWpNWk4rcDA9");
            InitializeComponent();

         /*   var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {*/
                await NavigationService.NavigateAsync("/PandemicMasterDetailPage/NavigationPage/HomePage");
           }/*
            else
            {
                await NavigationService.NavigateAsync("/PandemicMasterDetailPage/NavigationPage/LoginPage");

            }
        }*/

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<PandemicMasterDetailPage, PandemicMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AdminReportPage, AdminReportPageViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
