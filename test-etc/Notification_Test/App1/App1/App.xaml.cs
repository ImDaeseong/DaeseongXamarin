using Xamarin.Forms;
using App1.Interface;

namespace App1
{
    public partial class App : Application
    {
        public static INotification Notification { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new App1.MainPage();

            Notification = DependencyService.Get<INotification>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Notification.Start();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            //Notification.NotificationVersionOff();
        }
    }
}
