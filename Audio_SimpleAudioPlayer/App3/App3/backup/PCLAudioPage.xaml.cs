using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.SimpleAudioPlayer.Abstractions;
using System.IO;
using System.Reflection;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCLAudioPage : ContentPage
    {
        ISimpleAudioPlayer player;

        public PCLAudioPage()
        {
            InitializeComponent();
                        
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Load("Sounds/Urban Zakapa_I Don't Love You.mp3");

            InitControls();
        }

        void InitControls()
        {
            sliderVolume.Value = player.Volume;

            btnPlay.Clicked += BtnPlayClicked;
            btnPause.Clicked += BtnPauseClicked;
            btnStop.Clicked += BtnStopClicked;

            sliderVolume.ValueChanged += SliderVolumeValueChanged;
            sliderPosition.ValueChanged += SliderPostionValueChanged;

        }

        private void SliderPostionValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sliderPosition.Value != player.Duration)
                player.Seek(sliderPosition.Value);
        }

        private void SliderVolumeValueChanged(object sender, ValueChangedEventArgs e)
        {
            player.Volume = sliderVolume.Value;
        }

        private void BtnStopClicked(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void BtnPauseClicked(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {
            player.Play();
            player.Loop = true;

            sliderPosition.Maximum = player.Duration;
            sliderPosition.IsEnabled = player.CanSeek;

            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);
           
        }

        bool UpdatePosition()
        {
            string strCurTime = string.Format("{0:D2}:{1:D2}", (int)player.CurrentPosition / 60, (int)player.CurrentPosition % 60);
            string strTotalTime = string.Format("{0:D2}:{1:D2}", ((int)player.Duration  / 60),  (int)player.Duration  % 60);

            lblPosition.Text = strCurTime + "/" + strTotalTime;
            
            sliderPosition.ValueChanged -= SliderPostionValueChanged;
            sliderPosition.Value = player.CurrentPosition;
            sliderPosition.ValueChanged += SliderPostionValueChanged;

            return player.IsPlaying;
        }

        
    }
}
