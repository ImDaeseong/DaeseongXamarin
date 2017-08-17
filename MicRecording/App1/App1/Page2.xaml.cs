using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        bool isRecording = false;

        public Page2()
        {
            InitializeComponent();

            //App.AudioPlayer.AudioFilePath = Path.GetTempPath();
            //App.AudioRecorder.AudioFilePath = Path.GetTempPath();
        }

        private void start_Clicked(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                string audioFileName = Guid.NewGuid().ToString();
                App.AudioRecorder.AudioFileName = audioFileName;
                App.AudioPlayer.AudioFileName = audioFileName;
                App.AudioRecorder.StartRecord();
                start.Text = "Recording.......";
                isRecording = true;
            }
            else
            {
                start.Text = "Start Recording";
                App.AudioRecorder.StopRecord();
                isRecording = false;
            }
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            App.AudioPlayer.PlayAudio();
            /*
            if (File.Exists(App.AudioRecorder.AudioFilePath + "/" + App.AudioRecorder.AudioFileName + ".wav"))
                App.AudioPlayer.PlayAudio();
            */
        }



    }
}