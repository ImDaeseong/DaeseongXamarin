using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.SimpleAudioPlayer.Abstractions;

namespace App3
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

        private ISimpleAudioPlayer player;

        public clsSimpleAudio()
        {
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        }

        ~clsSimpleAudio()
        {
            
        }

        private string sDisplayText;
        public string DisplayText
        {
            get { return sDisplayText; }
            set { sDisplayText = value; }
        }

        public bool OnPause { get; set; }

        public bool Open(string strFile)
        {
            bool bOpen = false;
            bOpen = player.Load(strFile);            
            return bOpen;
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

        public bool Loop
        {
            get
            {
                return player.Loop;
            }
            set
            {
                player.Loop = value;
            }

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
