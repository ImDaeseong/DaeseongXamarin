using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;
using AVFoundation;
using Foundation;
using System.IO;

[assembly: Dependency(typeof(iOSAudioPlayer))]
namespace App1.iOS.Services
{
    public class iOSAudioPlayer : AudioPlayer
    {
        public AVAudioPlayer Player { get; set; }
        public NSError Error;
        public iOSAudioPlayer()
        {
            AudioFilePath = Path.GetTempPath();
        }
        
        void AudioPlayer.PlayAudio()
        {
            Player = new AVAudioPlayer(NSUrl.FromFilename(Path.Combine(AudioFilePath, AudioFileName + ".wav")), ".wav", out Error);
            Player.Play();
        }

        void AudioPlayer.StopAudio()
        {
            Player.Stop();
        }

        void AudioPlayer.PauseAudio()
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