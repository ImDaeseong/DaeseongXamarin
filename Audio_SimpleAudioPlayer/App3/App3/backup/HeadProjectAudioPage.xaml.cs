using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadProjectAudioPage : ContentPage
    {
        public HeadProjectAudioPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            player.Load("Sounds/Agnez Mo - Sebuah Rasa.mp3");


            btnPlay.Clicked += BtnPlayClicked;
            switchLoop.Toggled += SwitchLoopToggled;
        }

        private void SwitchLoopToggled(object sender, ToggledEventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Loop = switchLoop.IsToggled;
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Play();
        }

    }
}
