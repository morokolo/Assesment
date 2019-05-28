using System.Threading.Tasks;
using Oplay.Views;
using Prism;
using Prism.Ioc;
using Unity;
using Prism.Unity;
using Prism.Logging;
using Xamarin.Forms;
using Oplay.Services.Constants;
using Oplay.Services.Interfaces;
using Oplay.Services.Implementations;
using Oplay.Helpers.Interfaces;
using Oplay.Helpers.Implementations;
using Oplay.ViewModels;

namespace Oplay
{
    public partial class App: PrismApplication
    {
        /* 
         * NOTE: 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {}

        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override async void OnInitialized()
        {
            InitializeComponent();

            ServiceURLs.InitializeSettings();

            await SetAppLandingPage();
        }


        private async Task SetAppLandingPage()
        {

                await NavigationService.NavigateAsync(Constants.NavigationPaths.DASHBOARD_PAGE);

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasterDetailPageView, MasterDetailPageViewViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage>();
            containerRegistry.RegisterForNavigation<MyProfilePage>();
           
            containerRegistry.Register<IEmployeeService, EmployeeService>();
            containerRegistry.Register<ISecureStorage, SecureStorage>();
            containerRegistry.Register<IStorageHelper, StorageHelper>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }
    }
}
