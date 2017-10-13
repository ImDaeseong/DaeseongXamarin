using System;
using Xamarin.Forms;
using App1.Interface;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //App.Notification.NotificationOffAll();
            App.Notification.Show("title", "contents");
        }    

    }


}
