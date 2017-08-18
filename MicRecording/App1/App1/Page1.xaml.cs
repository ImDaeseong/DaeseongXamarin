using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Services;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private string sAudiopath;

        public Page1()
        {
            InitializeComponent();
        }

        private void start_Clicked(object sender, EventArgs e)
        {
            /*
            DependencyService.Get<IVoiceRecorder>().PrepareRecord();

            sAudiopath = DependencyService.Get<IVoiceRecorder>().GetPlayPath();

            DependencyService.Get<IVoiceRecorder>().Record();
            */


            DependencyService.Get<IMicRecording>().StartRecording();
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            //DependencyService.Get<IVoiceRecorder>().StopRecord();


            DependencyService.Get<IMicRecording>().StopRecording();
        }

        private void play_Clicked(object sender, EventArgs e)
        {
            //DependencyService.Get<IVoiceRecorder>().Play(sAudiopath);


            DependencyService.Get<IMicRecording>().PlayRecording();
        }

    }
}