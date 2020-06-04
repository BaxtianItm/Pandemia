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
using Pandemic.Common.Services;

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

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/PandemicMasterDetailPage/NavigationPage/ReportsHistoryPage");
           }
            else
            {
                await NavigationService.NavigateAsync("/PandemicMasterDetailPage/NavigationPage/DashboardPage");

            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.Register<IRegexHelper, RegexHelper>();
            containerRegistry.Register<IFilesHelper, FilesHelper>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<PandemicMasterDetailPage, PandemicMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AdminReportPage, AdminReportPageViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, ReportsHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangeStatusPage, ChangeStatusPageViewModel>();
            containerRegistry.RegisterForNavigation<AddDetailPage, AddDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<BarGraphPage, BarGraphPageViewModel>();
            containerRegistry.RegisterForNavigation<CakeGraphPage, CakeGraphPageViewModel>();
        }
    }
}
