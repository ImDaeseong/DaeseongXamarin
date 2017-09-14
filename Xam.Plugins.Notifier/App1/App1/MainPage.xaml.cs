using System;
using Xamarin.Forms;
using Plugin.LocalNotifications.Abstractions;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private ILocalNotifications localNotifications;

        public MainPage()
        {
            InitializeComponent();

            localNotifications = DependencyService.Get<ILocalNotifications>();
        }

        private void showNotificationButton_Clicked(object sender, EventArgs e)
        {
            localNotifications.Show("Title", "Body", 1);
        }

        private void cancelNotificationButton_Clicked(object sender, EventArgs e)
        {
            localNotifications.Cancel(1);
        }

    }
}
