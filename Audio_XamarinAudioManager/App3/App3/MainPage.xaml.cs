using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AudioManager;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            frame1.IsVisible = false;
            frame2.IsVisible = false;
            frame3.IsVisible = true;
        }

        protected override async void OnAppearing()
        {
            await Audio.Manager.PlayBackgroundMusic("K.will_ Growing.mp3");
                       
            Audio.Manager.MusicOn = true;
            Audio.Manager.BackgroundMusicVolume = 1;
            Audio.Manager.EffectsOn = true;
            Audio.Manager.EffectsVolume = 1;
            
            Background_AudioManagerMusicOn.IsToggled = Audio.Manager.MusicOn;
            EffectsAudioManagerEffectsOn.IsToggled = Audio.Manager.EffectsOn;

            //0 to 1
            AudioManagerBackgroundMusicVolume.Value = Audio.Manager.BackgroundMusicVolume;

            //0 to 1
            AudioManagerEffectsVolume.Value = Audio.Manager.EffectsVolume;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Audio.Manager.StopBackgroundMusic();
        }
        
        private void Background_AudioManagerMusicOn_Toggled(object sender, ToggledEventArgs e)
        {
            Audio.Manager.MusicOn = e.Value;
        }

        private void  EffectsAudioManagerEffectsOn_OnToggled(object sender, ToggledEventArgs e)
        {
            Audio.Manager.EffectsOn = e.Value;
        }

        private void AudioManagerBackgroundMusicVolume_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            Audio.Manager.BackgroundMusicVolume = (float)e.NewValue;
        }
        
        private void AudioManagerEffectsVolume_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            Audio.Manager.EffectsVolume = (float)e.NewValue;
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            if (Audio.Manager.MusicOn)
            {
                Audio.Manager.MusicOn = false;
            }
            else
            {
                Audio.Manager.MusicOn = true;
            }
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            if (Audio.Manager.MusicOn)
            {
                Audio.Manager.MusicOn = false;
                Audio.Manager.DeactivateAudioSession();
            }
            else
            {
                Audio.Manager.MusicOn = true;
                Audio.Manager.ReactivateAudioSession();
            }
        }

        private async void btn3_Clicked(object sender, EventArgs e)
        {
            await Audio.Manager.RestartBackgroundMusic();
        }

        private async void btn4_Clicked(object sender, EventArgs e)
        {
            await Audio.Manager.PlayBackgroundMusic("K.will_ Growing.mp3");
            
        }

        private async void btn5_Clicked(object sender, EventArgs e)
        {
            await Audio.Manager.PlaySound("K.will_ Growing.mp3");
        }

    }
}
