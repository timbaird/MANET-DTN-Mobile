using Xamarin.Forms;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.Controllers;

namespace MANET_DTN_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var service = DependencyService.Get<IWiFiConnectionService>();
            service.SetAlarm();

            //MainPage = new APITestView();

            MainPage = new NavigationPage(new MainMenuView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            LocalDBHandler.CreateDatabaseIfNeeded();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
