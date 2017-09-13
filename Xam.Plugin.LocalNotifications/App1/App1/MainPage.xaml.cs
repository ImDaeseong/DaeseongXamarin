using System;
using Xamarin.Forms;
using LocalNotifications.Plugin;
using LocalNotifications.Plugin.Abstractions;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            var notification = new LocalNotification
            {
                Title = "Title",
                Text = "Text",
                Id = 2,
                NotifyTime = DateTime.Now,
            };

            var notifier = CrossLocalNotifications.CreateLocalNotifier();
            notifier.Notify(notification);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {            
            var notifier = CrossLocalNotifications.CreateLocalNotifier();
            notifier.Notify(new LocalNotification()
            {
                Title = "",
                Text = "Text",
                Id = 3,
                NotifyTime = DateTime.Now.AddSeconds(1),
            });
        }

    }
}
