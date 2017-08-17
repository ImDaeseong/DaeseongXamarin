using System;
using Android.Media;
using System.IO;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(CVoiceRecorder))]
namespace App1.Droid.Services
{    
    class CVoiceRecorder : IVoiceRecorder
    {
        private MediaPlayer player;
        private MediaRecorder recorder;
        private string audioFilePath;
        public bool PrepareRecord()
        {
            try
            {
                string fileName = $"Myfile{DateTime.Now.ToString("yyyyMMddHHmmss")}.wav";
                audioFilePath = Path.Combine(Path.GetTempPath(), fileName);
                if (recorder == null)
                {
                    recorder = new MediaRecorder();
                }
                else
                {
                    recorder.Reset();
                }

                Console.WriteLine("daeseong1");

                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                recorder.SetAudioEncoder(AudioEncoder.Aac);
                recorder.SetOutputFile(audioFilePath);
                recorder.Prepare();

                Console.WriteLine("daeseong2");

                return true;
            }
            catch 
            {                
                return false;
            }
        }

        public string GetPlayPath()
        {
            return audioFilePath;
        }

        public bool Record()
        {
            try
            {
                recorder.Start();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public void Play(string path)
        {
            try
            {
                var ctx = Forms.Context;
                player = MediaPlayer.Create(ctx, Uri.Parse(path));
                player.Start();
            }
            catch
            {
                Console.WriteLine("daeseong3");
            }

        }

        public void StopRecord()
        {
            try
            {
                recorder.Stop();
                recorder.Reset();
                recorder.Release();
                MessagingCenter.Send(this, "voiceRecorded", audioFilePath);
            }
            catch
            {
                Console.WriteLine("daeseong4");
            }
        }
    }

}