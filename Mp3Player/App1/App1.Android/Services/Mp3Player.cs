﻿using System;
using System.Collections.Generic;
using Android.Media;
using Debug = System.Diagnostics.Debug;
using Android.Content.Res;
using Xamarin.Forms;
using App1.Droid;
using System.IO;

[assembly: Dependency(typeof(Mp3Player))]
namespace App1.Droid
{
    public class Mp3Player : IMp3Player
    {
        public event EventHandler PlayMp3Completed;
        
        private double dVolume = 0.5;
        private double dBalance = 0;

        private string mMp3value;
        public string MP3Value
        {
            get { return mMp3value;  }
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
        

        private MediaPlayer Player = null;
                
        private void InitMediaPlayer()
        {
            try
            {
                if (Player == null)
                {
                    Player = new MediaPlayer();
                    Player.Prepared += Player_Prepared;
                    Player.Completion += Player_Completion;
                }
                else
                {
                    Player.Reset();
                }

                string sSearch =  MP3Value.ToLower();
                if (sSearch.IndexOf("http://") >= 0 || sSearch.IndexOf("https://") >= 0)
                {
                    Player.SetAudioStreamType(Android.Media.Stream.Music);
                    Player.SetDataSource(MP3Value); 
                }
                else if (sSearch.IndexOf("storage/") >= 0)
                {
                    Player.SetDataSource(MP3Value);                 
                }
                else
                {
                    AssetFileDescriptor afd = Android.App.Application.Context.Assets.OpenFd(MP3Value);
                    Player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());

                mStatus = PlayStatus.Error;
                DestroyMediaPlayer();
            }
        }

        private void DestroyMediaPlayer()
        {
            try
            {
                Player.Prepared -= Player_Prepared;
                Player.Completion -= Player_Completion;

                Player.Stop();
                Player.Release();
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
                
                Player.Prepare();

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
            if (Player == null)
                return;

            if (Player.IsPlaying)
            {
                Player.Pause();
                mStatus = PlayStatus.Paused;
            }
            else
            {
                Player.Start();
                mStatus = PlayStatus.Playback;
            }
        }

        public void Stop()
        {
            if (Player == null)
                return;

            Player.Stop();
            Player.SeekTo(0);
            mStatus = PlayStatus.Stopped;
        }

        public double Duration
        {
            get { return Player == null ? 0 : ((double)Player.Duration) / 1000.0; }
        }

        public double CurrentPosition
        {
            get { return Player == null ? 0 : ((double)Player.CurrentPosition) / 1000.0; }
        }

        public bool IsPlaying
        {
            get { return Player == null ? false : Player.IsPlaying; }
        }

        public bool CanSeek
        {
            get { return Player == null ? false : true; }
        }

        public void Seek(double position)
        {
            if (Player != null)
                Player.SeekTo((int)position * 1000);
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
            dVolume = Math.Max(0, dVolume);
            dVolume = Math.Min(1, dVolume);

            dBalance = Math.Max(0, dBalance);
            dBalance = Math.Min(1, dBalance);

            var right = (dBalance < 0) ? dVolume * -1 * dBalance : dVolume;
            var left = (dBalance > 0) ? dVolume * 1 * dBalance : dVolume;

            Player.SetVolume((float)left, (float)right);
        }

        private void Player_Prepared(object sender, EventArgs e)
        {
            Player.Start();
            mStatus = PlayStatus.Playback;
        }
                
        private void Player_Completion(object sender, EventArgs e)
        {
            Player.Reset();
            mStatus = PlayStatus.Completed;
            PlayMp3Completed(this, e);
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
            string[] strfileList = Directory.GetFiles(strPath);
            foreach (string strFileName in strfileList)
            {
                if (GetFileExtName(strFileName).ToLower() == "mp3")
                    AryFilelist.Add(strFileName);
            }

            string[] strDirList = Directory.GetDirectories(strPath);
            foreach (string strDir in strDirList)
                SetFileInfo(strDir, AryFilelist);
        }

        public List<string> GetMusic()
        {
            var result = new List<string>();
            string folder_external = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Music";
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
