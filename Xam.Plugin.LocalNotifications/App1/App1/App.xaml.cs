using System;
using Xamarin.Forms;
using LocalNotifications.Plugin;
using LocalNotifications.Plugin.Abstractions;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new App1.MainPage();
        }

        protected override void OnStart()
        {
            var notifier = CrossLocalNotifications.CreateLocalNotifier();
            notifier.Notify(new LocalNotification()
            {
                Title = "Title",
                Text = "Text",
                Id = 1,
                NotifyTime = DateTime.Now.AddSeconds(10),
            });
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
