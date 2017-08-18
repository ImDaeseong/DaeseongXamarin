using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Controls;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private MicRecording MicRecord = MicRecording.getInstance;
                
        private bool IsRecording = false;
        private bool IsPrePlaying = false;
        private string sRecordText = "RecordText";

        public Page2()
        {
            InitializeComponent();
        }

        private void btnRecord_Clicked(object sender, EventArgs e)
        {           
            if (IsPrePlaying) return;
            
            try
            {
                if (!IsRecording)
                {
                    lblRecord.Text = "현재 녹음이 시작되었습니다.";
                    IsRecording = true;
                    btnRecord.BackgroundColor = Color.FromHex("#33A7D6");

                    MicRecord.SetAudioFilePath(sRecordText);
                    MicRecord.SetRecording(IsRecording);
                }
                else
                {
                    lblRecord.Text = "버튼을 클릭하면 녹음이 시작됩니다.";
                    IsRecording = false;
                    btnRecord.BackgroundColor = Color.Gray;

                    MicRecord.SetRecording(IsRecording);
                }
            }
            catch { }
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!IsRecording)
                {
                    string sPath = string.Format("{0}/{1}.wav", MicRecord.AudioFilePath, sRecordText);
                    if (!FilesManager.FileExists(sPath)) return;
                    if (IsPrePlaying) return;

                    lblRecord.Text = "녹음내용 미리 듣기 중입니다.";
                    IsPrePlaying = true;
                    MicRecord.PlayAudio();

                    totalTime.Text = MicRecord.GetTotalTimeDisplay();
                    currentTime.Text = MicRecord.GetCurrentTimeDisplay();
                    progress.Progress = MicRecord.GetCurrentPosition() * 1.0f / MicRecord.GetPosition();

                    UpdatePlayState();
                }
            }
            catch { }
        }

        private void UpdatePlayState()
        {
            Device.StartTimer(new TimeSpan(1000), () =>
            {
                progress.Progress = MicRecord.GetCurrentPosition() * 1.0f / MicRecord.GetPosition();

                currentTime.Text = MicRecord.GetCurrentTimeDisplay();

                bool bPlay = MicRecord.IsPlaying();
                if (!bPlay)
                {
                    lblRecord.Text = "버튼을 클릭하면 녹음이 시작됩니다.";
                    IsPrePlaying = false;

                    totalTime.Text = "00:00";
                    currentTime.Text = "00:00";
                    progress.Progress = 0;
                }

                return bPlay;
            });
        }


    }
}