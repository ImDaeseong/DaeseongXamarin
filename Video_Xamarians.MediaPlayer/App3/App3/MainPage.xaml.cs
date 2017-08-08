using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {   
        public MainPage()
        {
            InitializeComponent();           
        }

        private bool OnTimerTick()
        {
            Start();

            return true;
        }

        private void Start()
        {
            VideoPlayer.Source = "http://techslides.com/demos/sample-videos/small.mp4";
            VideoPlayer.AutoPlay = true;
            VideoPlayer.Play();
        }
               
        private async void VideoPlayer_Error(object sender, Xamarians.MediaPlayer.PlayerErrorEventArgs e)
        {            
            await DisplayAlert("Error", e.Message, "OK");            
        }

        private async void VideoPlayer_Prepared(object sender, EventArgs e)
        {
            await DisplayAlert("", "Prepared", "OK");
        }

        private async void VideoPlayer_Completed(object sender, EventArgs e)
        {
            await DisplayAlert("", "Completed", "OK");
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            Device.StartTimer(TimeSpan.FromSeconds(5), OnTimerTick);
            //VideoPlayer.IsVisible = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            VideoPlayer.Pause();
            //VideoPlayer.IsVisible = false;
        }

    }
}
