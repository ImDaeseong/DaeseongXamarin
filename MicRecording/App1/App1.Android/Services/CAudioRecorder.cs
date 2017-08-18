using Android.Media;
using System.IO;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CAudioRecorder))]
namespace App1.Droid.Services
{   
    public class CAudioRecorder : AudioRecorder
    {
        public MediaRecorder Recorder { get; set; }

        public CAudioRecorder()
        {
            Recorder = new MediaRecorder();

            AudioFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //AudioFilePath = Path.GetTempPath();
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