using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;
using Android.Media;
using System.IO;

[assembly: Dependency(typeof(AndroidAudioRecorder))]
namespace App1.Droid.Services
{
    public class AndroidAudioRecorder : AudioRecorder
    {
        public MediaRecorder Recorder { get; set; }
        public AndroidAudioRecorder()
        {
            Recorder = new MediaRecorder();

            AudioFilePath = Path.GetTempPath();
        }
                
        public void StartRecord()
        {
            Recorder.SetAudioSource(AudioSource.Mic);
            Recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            Recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            Recorder.SetOutputFile(AudioFilePath + "/" + AudioFileName + ".wav");
            Recorder.Prepare();
            Recorder.Start();
        }

        public void StopRecord()
        {
            Recorder.Stop();
            Recorder.Reset();
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