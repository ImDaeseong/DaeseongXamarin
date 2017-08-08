using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    public class clsSimpleAudio
    {
        private static clsSimpleAudio selfInstance = null;
        public static clsSimpleAudio getInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new clsSimpleAudio();
                return selfInstance;
            }
        }

        private IMp3Player player;

        public event EventHandler PlayMp3CompletedNotice;

        public clsSimpleAudio()
        {
            player = DependencyService.Get<IMp3Player>();
            player.PlayMp3Completed += Player_PlayMp3Completed;
        }

        private void Player_PlayMp3Completed(object sender, EventArgs e)
        {
            PlayMp3CompletedNotice(this, e);
        }

        ~clsSimpleAudio()
        {
            player.PlayMp3Completed -= Player_PlayMp3Completed;
        }

        private string sDisplayText;
        public string DisplayText
        {
            get { return sDisplayText; }
            set { sDisplayText = value; }
        }
        
        public void Open(string strFile)
        {
            player.MP3Value = strFile;
        }

        public void Play()
        {
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }

        public void Pause()
        {
            player.Pause();
        }

        public bool IsPlaying()
        {
            return player.IsPlaying;
        }
                

        public double Volume
        {
            get
            {
                return player.Volume;
            }
            set
            {
                player.Volume = value;
            }
        }

        public double GetPosition()
        {
            return player.Duration;
        }

        public void SetPosition(double dValue)
        {
            player.Seek(dValue);
        }

        public double GetCurrentPosition()
        {
            return player.CurrentPosition;
        }

        public bool CanSeek()
        {
            return player.CanSeek;
        }

        public void SkipBack()
        {
            double pos = GetCurrentPosition();
            pos -= 1000;
            SetPosition(pos);
        }

        public void SkipForward()
        {
            double pos = GetCurrentPosition();
            pos += 1000;
            SetPosition(pos);
        }

        public string GetCurrentTimeDisplay()
        {
            string strCurTime = "";
            strCurTime = string.Format("{0:D2}:{1:D2}", (int)player.CurrentPosition / 60, (int)player.CurrentPosition % 60);
            return strCurTime;
        }

        public string GetTotalTimeDisplay()
        {
            string strTotalTime = "";
            strTotalTime = string.Format("{0:D2}:{1:D2}", ((int)player.Duration / 60), (int)player.Duration % 60);
            return strTotalTime;
        }

        public List<string> GetMusic()
        {
            return player.GetMusic();
        }                
    }
    
    public class Music
    {
        private string filename;

        public string Mp3
        {
            get { return filename; }
            set { filename = value; }
        }
    }

}
