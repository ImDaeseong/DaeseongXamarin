using Xamarin.Forms;
using App1.Services;

namespace App1.Controls
{
    public class MicRecording
    {
        private static MicRecording selfInstance = null;
        public static MicRecording getInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new MicRecording();
                return selfInstance;
            }
        }

        static AudioPlayer AudioPlayer
        {
            get
            {
                return DependencyService.Get<AudioPlayer>();
            }
        }

        static AudioRecorder AudioRecorder
        {
            get
            {
                return DependencyService.Get<AudioRecorder>();
            }
        }

        public string AudioFilePath
        {
            get
            {
                return AudioPlayer.AudioFilePath;
            }            
        }

        public string AudioFileName
        {
            get
            {
                return AudioPlayer.AudioFileName;
            }
        }

        public void SetAudioFilePath(string sFileName)
        {
            AudioPlayer.AudioFileName = sFileName;
            AudioRecorder.AudioFileName = sFileName;
        }

        public void SetRecording(bool bIsRecording)
        {
            if (bIsRecording)
                AudioRecorder.StartRecord();
            else
                AudioRecorder.StopRecord();
        }

        public void PlayAudio()
        {
            AudioPlayer.PlayAudio();
        }

        public void StopAudio()
        {
            AudioPlayer.StopAudio();
        }

        public bool IsPlaying()
        {
            return AudioPlayer.IsPlaying;
        }

        public double GetPosition()
        {
            return AudioPlayer.Duration;
        }
        
        public double GetCurrentPosition()
        {
            return AudioPlayer.CurrentPosition;
        }

        public string GetCurrentTimeDisplay()
        {
            string strCurTime = "";
            strCurTime = string.Format("{0:D2}:{1:D2}", (int)GetCurrentPosition() / 60, (int)GetCurrentPosition() % 60);
            return strCurTime;
        }

        public string GetTotalTimeDisplay()
        {
            string strTotalTime = "";
            strTotalTime = string.Format("{0:D2}:{1:D2}", ((int)GetPosition() / 60), (int)GetPosition() % 60);
            return strTotalTime;
        }

    }
}
