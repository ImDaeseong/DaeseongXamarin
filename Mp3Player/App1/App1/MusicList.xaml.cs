using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicList : ContentPage
    {
        private clsSimpleAudio simplePlay = clsSimpleAudio.getInstance;

        private int CurrentPlayIndex = -1;

        private List<MusicFile> musicList;
        private double dX;
        private double dY;

        private string GetFileName(string strFilename)
        {
            int nPos = strFilename.LastIndexOf('/');
            int nLength = strFilename.Length;
            if (nPos < nLength)
                return strFilename.Substring(nPos + 1, (nLength - nPos) - 1);
            return strFilename;
        }

        private async void MessageBox(string sMessage)
        {
            await DisplayAlert("Information", sMessage, "OK");
        }

        private async void LoadMusic()
        {
            await Task.Factory.StartNew(() =>
            {          
                var MusicList = simplePlay.GetMusic();
                for (int i = 0; i < MusicList.Count; i++)
                {
                    musicList.Add(new MusicFile(MusicList[i], GetFileName(MusicList[i])));
                }
                MusicList.Clear();  
                /*
                musicList.Add(new MusicFile("Sounds/Black Out.mp3", "IU(아이유) - Black Out"));
                musicList.Add(new MusicFile("Sounds/Ending Scene.mp3", "IU(아이유) - Ending Scene(이런 엔딩)"));
                musicList.Add(new MusicFile("Sounds/Jam Jam.mp3", "IU(아이유) - Jam Jam"));
                musicList.Add(new MusicFile("Sounds/Not Spring, Love, or Cherry Blossoms.mp3", "IU(아이유) - Not Spring, Love, or Cherry Blossoms"));
                musicList.Add(new MusicFile("Sounds/Palette.mp3", "IU(아이유) - Palette(팔레트)"));
                musicList.Add(new MusicFile("Sounds/Through the Night.mp3", "IU(아이유) - Through the Night(밤편지)"));
                musicList.Add(new MusicFile("Sounds/now.mp3", "IU(아이유) - 이 지금"));
                musicList.Add(new MusicFile("Sounds/name1.mp3", "IU(아이유) - 이름에게"));
                //musicList.Add(new MusicFile("http://127.0.0.1/test.mp3", "http url"));
                */
            });
        }
        
        public MusicList()
        {
            InitializeComponent();

            DependencyService.Get<IStatusBar>().HideStatusBar();

            simplePlay.PlayMp3CompletedNotice += SimplePlay_PlayMp3CompletedNotice;

            InitImageButton();

            LogoImageAni.IsVisible = false;

            dX = LogoImage.TranslationX;
            dY = LogoImage.TranslationY;

            musicList = new List<MusicFile>();
            MusicListview.ItemsSource = musicList;
            MusicListview.ItemSelected += MusicListview_ItemSelected;
            MusicListview.ItemTapped += MusicListview_ItemTapped;

            LoadMusic();

            if (XamarinAppSettings.MusicToken > 0)
            {
                CurrentPlayIndex = XamarinAppSettings.MusicToken;

                Play(CurrentPlayIndex);
                UpdatePlayState();

                Debug.WriteLine("CurrentPlayIndex:" + CurrentPlayIndex);
            }            
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

        private void MusicListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var Music = (MusicFile)e.Item;
                CurrentPlayIndex = musicList.IndexOf(Music);
                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Debug.WriteLine("MusicListview_ItemTapped");
            }
        }

        private void MusicListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var Music = (MusicFile)e.SelectedItem;
                CurrentPlayIndex = musicList.IndexOf(Music);
                MusicListview.SelectedItem = null;
            }
        }

        private async void TapGestureRecognizer_TappedPrePlayMusic(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(500);

                if (musicList.Count == 0) return;

                CurrentPlayIndex--;

                if (CurrentPlayIndex < 0)
                    CurrentPlayIndex = musicList.Count - 1;

                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Debug.WriteLine("TapGestureRecognizer_TappedPrePlayMusic");
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Debug.WriteLine("TapGestureRecognizer_TappedPlay");
            }
        }

        private async void TapGestureRecognizer_TappedNextPlayMusic(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(500);

                if (musicList.Count == 0) return;

                CurrentPlayIndex++;

                if (CurrentPlayIndex > (musicList.Count - 1))
                    CurrentPlayIndex = 0;

                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Debug.WriteLine("TapGestureRecognizer_TappedNextPlayMusic");
            }
        }

        async void LoadAni()
        {
            try
            {
                LogoImageAni.IsVisible = true;

                await Animate.BallAnimate(LogoImage, 50, 10, 5, dX, dY);

                //hide
                await LogoImageAni.FadeTo(0, 1000);

                LogoImageAni.IsVisible = false;

                //show
                await LogoImageAni.FadeTo(1, 1000);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Debug.WriteLine("LoadAni");
            }
        }

        private void Play(int nIndex)
        {
            if (musicList.Count == 0) return;

            CurrentPlayIndex = nIndex;

            Debug.WriteLine("Music Index:" + CurrentPlayIndex);

            simplePlay.Open(musicList[CurrentPlayIndex].Name);

            simplePlay.Play();
                       
            currentMusicName.Text = simplePlay.DisplayText = "현재 플레이 " + musicList[CurrentPlayIndex].ViewName;

            totalTime.Text = simplePlay.GetTotalTimeDisplay();
            currentTime.Text = simplePlay.GetCurrentTimeDisplay();

            LoadAni();

            TickerLabel.Content = simplePlay.DisplayText;
            TickerLabel.Run(true);
        }

        private void SimplePlay_PlayMp3CompletedNotice(object sender, EventArgs e)
        {
            bool bPlay = simplePlay.IsPlaying();
            if (!bPlay)
            {                
                if (musicList.Count == 0) return;

                CurrentPlayIndex++;

                if (CurrentPlayIndex > (musicList.Count - 1))
                    CurrentPlayIndex = 0;
                
                Play(CurrentPlayIndex);
                UpdatePlayState();
            }
        }

        private void UpdatePlayState()
        {
            Device.StartTimer(new TimeSpan(1000), () =>
            {
                currentMusicName.Text = simplePlay.DisplayText;

                progress.Progress = simplePlay.GetCurrentPosition() * 1.0f / simplePlay.GetPosition();

                currentTime.Text = simplePlay.GetCurrentTimeDisplay();

                bool bPlay = simplePlay.IsPlaying();
                return bPlay;
            });
        }

        protected override void OnAppearing()
        {
            bool bPlay = simplePlay.IsPlaying();
            if (bPlay)
            {
                UpdatePlayState();
            }
            else
            {
                currentMusicName.Text = simplePlay.DisplayText;
                progress.Progress = simplePlay.GetCurrentPosition() * 1.0f / simplePlay.GetPosition();
            }

            totalTime.Text = simplePlay.GetTotalTimeDisplay();
            currentTime.Text = simplePlay.GetCurrentTimeDisplay();

            TickerLabel.Content = simplePlay.DisplayText;
            TickerLabel.Run(true);

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {            
            base.OnDisappearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        protected override bool OnBackButtonPressed()
        {
            XamarinAppSettings.MusicToken = CurrentPlayIndex;

            //DependencyService.Get<ICloseApplication>().CloseApp();

            return base.OnBackButtonPressed();
        }

    }

    class MusicFile
    {
        public string Name { get; set; }
        public string ViewName { get; set; }

        public MusicFile(string Name, string ViewName)
        {
            this.Name = Name;
            this.ViewName = ViewName;
        }
    }

    public class Animate
    {
        public static async Task BallAnimate(View view, int Top, int reduce, int time, double dX, double dY)
        {
            await view.RelRotateTo(360, 1000);

            do
            {
                await view.TranslateTo(dX, dY - Top, 500, Easing.CubicOut);//await view.TranslateTo(view.TranslationX, view.TranslationY - Top, 500, Easing.CubicOut);

                await view.TranslateTo(dX, dY + Top, 300, Easing.CubicIn);//await view.TranslateTo(view.TranslationX, view.TranslationY + Top, 300, Easing.CubicIn);

                Top = Top - reduce;
                time--;
            } while (time != 0);

        }
    }
}