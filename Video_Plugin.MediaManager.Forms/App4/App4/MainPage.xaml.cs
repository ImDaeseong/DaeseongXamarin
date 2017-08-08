using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        private bool bIsPlay = false;
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public MainPage()
        {
            InitializeComponent();

            CrossMediaManager.Current.PlayingChanged += Current_PlayingChanged;
        }

        private void Current_PlayingChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.PlayingChangedEventArgs e)
        {
            string sProgress = string.Format("{0} %", e.Progress);
            string sDuration = string.Format("{0} seconds", e.Duration.TotalSeconds.ToString());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PlaybackController.Play();
            bIsPlay = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PlaybackController.Stop();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (bIsPlay)
            {
                PlaybackController.Pause();
                bIsPlay = false;
            }
            else
            {
                PlaybackController.Play();
                bIsPlay = true;
            }
        }
    }
}
