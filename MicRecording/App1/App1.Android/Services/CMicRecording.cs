using System;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;
using Android.Media;
using System.IO;

[assembly: Dependency(typeof(CMicRecording))]
namespace App1.Droid.Services
{
    public class CMicRecording : IMicRecording
    {
        private string audioFilePath;

        static string filePath = "/data/data/XamarinSecurityTests.Android/files/testAudio.mp4";
        public CMicRecording()
        {
        }
                
        protected MediaRecorder recorder;
        protected MediaPlayer player;

        public void StartRecording()
        {
            string fileName = $"Myfile{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4";
            audioFilePath = Path.Combine(Path.GetTempPath(), fileName);

            try
            {
                if (File.Exists(audioFilePath))
                {
                    File.Delete(audioFilePath);
                }

                if (recorder == null)
                {
                    recorder = new MediaRecorder();
                }

                recorder.Reset();
                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Mpeg4);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                // Initialized state.
                recorder.SetOutputFile(audioFilePath);
                // DataSourceConfigured state.
                recorder.Prepare(); // Prepared state
                recorder.Start(); // Recording state.
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public string GetPlayPath()
        {
            return audioFilePath;
        }

        public void StopRecording()
        {
            try
            {
                if (recorder != null)
                {
                    recorder.Stop();

                    recorder.Reset();
                    recorder.Release();
                    recorder = null;
                }
            }
            catch { } 
        }

        public void PlayRecording()
        {
            try
            {

                if (player == null)
                {
                    player = new MediaPlayer();
                }

                if (File.Exists(audioFilePath))
                {
                    player.Reset();
                    player.SetDataSource(audioFilePath);
                    player.Prepare();
                    player.Start();
                }
            }catch { }
        }
        
    }
}