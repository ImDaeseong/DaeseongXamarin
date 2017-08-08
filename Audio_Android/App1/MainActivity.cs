using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Collections.Generic;
using System.IO;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MediaPlayer mPlayer = null;
        private List<string> mItem = null;

        private Button btnPlay, btnPause, btnStop;
        private ListView lstMusic;
        private TextView txtFilePath;

        private void InitControls()
        {
            if (mPlayer == null)
            {
                mPlayer = new MediaPlayer();
                mPlayer.Prepared += MPlayer_Prepared;
                mPlayer.Completion += MPlayer_Completion;
            }
            else
            {
                mPlayer.Reset();
            }

            mItem = new List<string>();

            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPause = FindViewById<Button>(Resource.Id.btnPause);
            btnStop = FindViewById<Button>(Resource.Id.btnStop);
            lstMusic = FindViewById<ListView>(Resource.Id.lstMusic);
            txtFilePath = FindViewById<TextView>(Resource.Id.filePath);

            btnPlay.Click += BtnPlay_Click;
            btnPause.Click += BtnPause_Click;
            btnStop.Click += BtnStop_Click;
            lstMusic.ItemClick += LstMusic_ItemClick;
                       
            string sFilePath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Music/music/test.mp3";                      
            txtFilePath.Text = sFilePath;

            //All Directory Search
            var MusicList = GetMusic();
            for (int i = 0; i < GetMusic().Count; i++)
                mItem.Add(MusicList[i]);
            MusicList.Clear();

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItem);
            lstMusic.Adapter = adapter;

            try
            {
                mPlayer.SetDataSource(sFilePath);
                mPlayer.Prepare();
            }
            catch (System.Exception ex)
            {                
                System.Console.WriteLine(ex.Message.ToString());
            }           
        }

        private void MPlayer_Completion(object sender, System.EventArgs e)
        {
            mPlayer.Reset();
        }

        private void MPlayer_Prepared(object sender, System.EventArgs e)
        {
            mPlayer.Start();
        }

        private void LstMusic_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string sitem = this.lstMusic.GetItemAtPosition(e.Position).ToString();
            Toast.MakeText(this, sitem + " Clicked!", ToastLength.Short).Show();

            try
            {
                if (mPlayer == null)
                {
                    mPlayer = new MediaPlayer();
                    mPlayer.Prepared += MPlayer_Prepared;
                    mPlayer.Completion += MPlayer_Completion;
                }
                else
                    mPlayer.Reset();
                
                mPlayer.SetDataSource(sitem);
                mPlayer.Prepare();                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
            }            
        }

        private void BtnStop_Click(object sender, System.EventArgs e)
        {
            mPlayer.Stop();
        }

        private void BtnPause_Click(object sender, System.EventArgs e)
        {
            if( mPlayer.IsPlaying)
                mPlayer.Pause();
            else
                mPlayer.Start();
        }

        private void BtnPlay_Click(object sender, System.EventArgs e)
        {            
            mPlayer.Start();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            InitControls();
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

    }
}

