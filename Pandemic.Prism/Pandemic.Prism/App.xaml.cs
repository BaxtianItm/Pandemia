using Prism;
using Prism.Ioc;
using Pandemic.Prism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pandemic.Prism.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Pandemic.Prism
{
    public partial class App
    {
        
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<PandemicMasterDetailPage, PandemicMasterDetailPageViewModel>();
        }
    }
}
