using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicAllPage : ContentPage
    {
        private clsSimpleAudio simplePlay = clsSimpleAudio.getInstance;
        private List<MusicAllFile> musicAllList;
        private bool isReady;
        private int CurrentPlayIndex = -1;

        private string GetFileName(string strFilename)
        {
            int nPos = strFilename.LastIndexOf('/');
            int nLength = strFilename.Length;
            if (nPos < nLength)
                return strFilename.Substring(nPos + 1, (nLength - nPos) - 1);
            return strFilename;
        }

        private void InitImageButton()
        {
            var tapPrePayImage = new TapGestureRecognizer();
            tapPrePayImage.Tapped += (s, e) => {
                TapGestureRecognizer_TappedPrePlayMusic(this, null);
            };
            PrePayImage.GestureRecognizers.Add(tapPrePayImage);

            var tapplayImagee = new TapGestureRecognizer();
            tapplayImagee.Tapped += (s, e) => {
                TapGestureRecognizer_TappedPlay(this, null);
            };
            playImage.GestureRecognizers.Add(tapplayImagee);

            var tapnextplayImage = new TapGestureRecognizer();
            tapnextplayImage.Tapped += (s, e) => {
                TapGestureRecognizer_TappedNextPlayMusic(this, null);
            };
            nextplayImage.GestureRecognizers.Add(tapnextplayImage);
        }

        private async void TapGestureRecognizer_TappedPrePlayMusic(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(500);

                if (musicAllList.Count == 0) return;

                CurrentPlayIndex--;

                if (CurrentPlayIndex < 0)
                    CurrentPlayIndex = musicAllList.Count - 1;

                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
            catch 
            {
                App.WriteString("MusicAllPage TapGestureRecognizer_TappedPrePlayMusic Failed");
            }
        }

        private async void TapGestureRecognizer_TappedPlay(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(500);
                simplePlay.Pause();
                UpdatePlayState();
            }
            catch 
            {
                App.WriteString("MusicAllPage TapGestureRecognizer_TappedPlay Failed");
            }
        }

        private async void TapGestureRecognizer_TappedNextPlayMusic(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(500);

                if (musicAllList.Count == 0) return;

                CurrentPlayIndex++;

                if (CurrentPlayIndex > (musicAllList.Count - 1))
                    CurrentPlayIndex = 0;

                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
            catch 
            {
                App.WriteString("MusicAllPage TapGestureRecognizer_TappedNextPlayMusic Failed");
            }
        }

        private void Play(int nIndex)
        {
            if (musicAllList.Count == 0) return;

            CurrentPlayIndex = nIndex;

            Debug.WriteLine("Music Index:" + CurrentPlayIndex);

            simplePlay.Open(musicAllList[CurrentPlayIndex].Name);

            simplePlay.Play();
   
            totalTime.Text = simplePlay.GetTotalTimeDisplay();
            currentTime.Text = simplePlay.GetCurrentTimeDisplay();
        }

        private void SimplePlay_PlayMp3CompletedNotice(object sender, EventArgs e)
        {
            bool bPlay = simplePlay.IsPlaying();
            if (!bPlay)
            {
                if (musicAllList.Count == 0) return;

                CurrentPlayIndex++;

                if (CurrentPlayIndex > (musicAllList.Count - 1))
                    CurrentPlayIndex = 0;

                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
        }

        private void UpdatePlayState()
        {
            Device.StartTimer(new TimeSpan(1000), () =>
            {
                progress.Progress = simplePlay.GetCurrentPosition() * 1.0f / simplePlay.GetPosition();

                currentTime.Text = simplePlay.GetCurrentTimeDisplay();

                bool bPlay = simplePlay.IsPlaying();
                return bPlay;
            });
        }

        public MusicAllPage()
        {
            InitializeComponent();
            
            try
            {
                BackgroundColor = Color.FromHex("#253648");
                
                InitImageButton();

                simplePlay.PlayMp3CompletedNotice += SimplePlay_PlayMp3CompletedNotice;

                musicAllList = null;
                musicAllList = new List<MusicAllFile>();
                MusicAllList.ItemsSource = musicAllList;
                MusicAllList.ItemTapped += MusicAllList_ItemTapped;
                
                LoadData();

                MusicAllList.IsVisible = true;
                actIndicator.IsRunning = false;
                actIndicatorStackLayout.IsVisible = false;
            }
            catch
            {
                App.WriteString("MusicAllPage MusicAllPage Failed");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
            //return base.OnBackButtonPressed();
        }

        private async void LoadData()
        {
            await Task.Factory.StartNew(() =>
            {
                var MusicList = simplePlay.GetMusic();
                for (int i = 0; i < MusicList.Count; i++)
                {
                    musicAllList.Add(new MusicAllFile(MusicList[i], GetFileName(MusicList[i])));
                    Task.Delay(TimeSpan.FromMilliseconds(22));
                }
                MusicList.Clear();
                isReady = true;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (XamarinAppSettings.PageName != "MusicAllPage")
                {
                    XamarinAppSettings.PageName = "MusicAllPage";
                }
                else
                {
                    //check playing
                    bool bPlay = simplePlay.IsPlaying();
                    if (bPlay)
                    {
                        UpdatePlayState();
                    }
                    else
                    {
                        progress.Progress = simplePlay.GetCurrentPosition() * 1.0f / simplePlay.GetPosition();
                    }

                    totalTime.Text = simplePlay.GetTotalTimeDisplay();
                    currentTime.Text = simplePlay.GetCurrentTimeDisplay();
                }
            }
            catch 
            {
                App.WriteString("MusicAllPage OnAppearing Failed");
            }
        }

        private void MusicAllList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item == null || !isReady) return;

                var Music = (MusicAllFile)e.Item;
                CurrentPlayIndex = musicAllList.IndexOf(Music);
                Play(CurrentPlayIndex);
                UpdatePlayState();

                ((ListView)sender).SelectedItem = null;
            }
            catch 
            {
                App.WriteString("MusicAllPage MusicAllList_ItemTapped Failed");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            App.CurrentIndex = 1;
            XamarinAppSettings.PageName = "MusicAllPage";
        }

    }

    class MusicAllFile
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public MusicAllFile(string Name, string DisplayName)
        {
            this.Name = Name;
            this.DisplayName = DisplayName;
        }
    }

}