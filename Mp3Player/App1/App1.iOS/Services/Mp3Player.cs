using System;
using Foundation;
using AVFoundation;
using Xamarin.Forms;
using App1.iOS;
using Debug = System.Diagnostics.Debug;
using System.Collections.Generic;

//아이폰도 없고 맥도 없어서 테스트 못함
[assembly: Dependency(typeof(Mp3Player))]
namespace App1.iOS
{
    public class Mp3Player : IMp3Player
    {
        public event EventHandler PlayMp3Completed;

        private double dVolume = 0.5;
        private double dBalance = 0;

        private string mMp3value;
        public string MP3Value
        {
            get { return mMp3value; }
            set { mMp3value = value; }
        }

        private PlayStatus mStatus;
        private enum PlayStatus
        {
            Stopped,
            Error,
            Buffering,
            Playback,
            Paused,
            Completed
        }
               
        private AVAudioPlayer Player = null;

        private void InitMediaPlayer()
        {
            try
            {
                var url = NSUrl.FromString(MP3Value);
                Player = AVAudioPlayer.FromUrl(url);

                Player.BeginInterruption += Player_BeginInterruption;
                Player.FinishedPlaying += Player_FinishedPlaying;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());

                mStatus = PlayStatus.Error;
                DestroyMediaPlayer();
            }
        }

        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {           
            Player.Stop();
            Player.Dispose();
            mStatus = PlayStatus.Completed;
            PlayMp3Completed(this, e);
        }

        private void Player_BeginInterruption(object sender, EventArgs e)
        {
            Player.Play();
            mStatus = PlayStatus.Playback;
        }

        private void DestroyMediaPlayer()
        {
            try
            {
                Player.BeginInterruption -= Player_BeginInterruption;
                Player.FinishedPlaying -= Player_FinishedPlaying;

                Player.Stop();
                Player.Dispose();
                Player = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
        }

        public void Play()
        {
            try
            {
                InitMediaPlayer();

                Player.PrepareToPlay();
                mStatus = PlayStatus.Buffering;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());

                mStatus = PlayStatus.Error;
                DestroyMediaPlayer();
            }
        }

        public void Pause()
        {
            if (Player.Playing)
            {
                Player.Pause();
                mStatus = PlayStatus.Paused;
            }
            else
            {
                Player.Play();
                mStatus = PlayStatus.Playback;
            }
        }

        public void Stop()
        {
            Player.Stop();
            Seek(0);
            mStatus = PlayStatus.Stopped;
        }

        public void Seek(double position)
        {
            if (Player != null)
                Player.CurrentTime = position;
        }

        public double Duration
        {
            get { return Player == null ? 0 : Player.Duration; }
        }

        public double CurrentPosition
        {
            get { return Player == null ? 0 : Player.CurrentTime; }
        }

        public bool IsPlaying
        {
            get { return Player == null ? false : Player.Playing; }
        }

        public bool CanSeek
        {
            get { return Player == null ? false : true; }
        }

        public double Volume
        {
            get { return dVolume; }
            set { SetVolume(dVolume = value, Balance); }
        }
        
        public double Balance
        {
            get { return dBalance; }
            set { SetVolume(Volume, dBalance = value); }
        }

        private void SetVolume(double dVolume, double dBalance)
        {
            if (Player == null)
                return;

            dVolume = Math.Max(0, dVolume);
            dVolume = Math.Min(1, dVolume);

            dBalance = Math.Max(0, dBalance);
            dBalance = Math.Min(1, dBalance);

            var right = (dBalance < 0) ? dVolume * -1 * dBalance : dVolume;
            var left = (dBalance > 0) ? dVolume * 1 * dBalance : dVolume;

            Player.SetVolume((float)left, (float)right);
        }

        private string GetFileExtName(string strFilename)
        {
            int nPos = strFilename.LastIndexOf('.');
            int nLength = strFilename.Length;
            if (nPos < nLength)
                return strFilename.Substring(nPos + 1, (nLength - nPos) - 1);
            return string.Empty;
        }
        private void SetFileInfo(string strPath, List<string> AryFilelist)
        {
        }

        public List<string> GetMusic()
        {
            var result = new List<string>();
            string folder_external = "";// Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Music";
            SetFileInfo(folder_external, result);
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DestroyMediaPlayer();
                }
                
                disposedValue = true;
            }
        }

        ~Mp3Player()
        {
            Dispose(false);
        }
       
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}