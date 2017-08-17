using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;
using Android.Media;
using System.IO;

[assembly: Dependency(typeof(AndroidAudioPlayer))]
namespace App1.Droid.Services
{
    public class AndroidAudioPlayer : AudioPlayer
    {
        public MediaPlayer Player { get; set; }
        public AndroidAudioPlayer()
        {
            Player = new MediaPlayer();

            AudioFilePath = Path.GetTempPath();
        }
        
        public void PlayAudio()
        {
            Player.Completion += (sender, e) => {
                Player.Reset();
            };
            Player.SetDataSource(AudioFilePath + "/" + AudioFileName + ".wav");
            Player.Prepare();
            Player.Start();
        }

        public void StopAudio()
        {
            Player.Stop();
        }

        public void PauseAudio()
        {
            Player.Pause();
        }

        private string audioFileName;
        public string AudioFileName
        {
            get
            {
                return audioFileName;
            }
            set
            {
                audioFileName = value;
            }
        }

        private string audioFilePath;
        public string AudioFilePath
        {
            get
            {
                return audioFilePath;
            }
            set
            {
                audioFilePath = value;
            }
        }
        
    }
}