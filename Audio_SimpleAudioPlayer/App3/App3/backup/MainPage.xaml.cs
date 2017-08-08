using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        private clsSimpleAudio simplePlay = clsSimpleAudio.getInstance;

        protected bool bStopTimer = false;

        private List<Music> MusicList;
        
        private int m_nIndex = 0;
        private string m_strCurrentMp3Path = "";
        private double m_dVolume = 0.5;

        private void PrePlayMusic()
        {
            if (MusicList.Count == 0) return;

            m_nIndex--;

            if (m_nIndex < 0)
                m_nIndex = MusicList.Count - 1;

            m_strCurrentMp3Path = MusicList[m_nIndex].Mp3;

            Stop();
            Play();
        }

        private void NextPlayMusic(bool bFirstPlay = false)
        {
            if (MusicList.Count == 0) return;

            if (bFirstPlay)
            {
                m_nIndex = 0;
                m_strCurrentMp3Path = MusicList[m_nIndex].Mp3;

                Stop();
                Play();
            }
            else
            {
                m_nIndex++;

                if (m_nIndex > (MusicList.Count - 1))
                    m_nIndex = 0;

                m_strCurrentMp3Path = MusicList[m_nIndex].Mp3;

                Stop();
                Play();
            }
        }

        private void Play()
        {
            simplePlay.Open(m_strCurrentMp3Path);
                        
            bStopTimer = false;

            simplePlay.Play();

            //simplePlay.Loop = true;

            sliderPosition.Maximum = simplePlay.GetPosition();
            sliderPosition.IsEnabled = simplePlay.CanSeek();

            sliderVolume.Value = m_dVolume;
            simplePlay.Volume = m_dVolume;

            Device.StartTimer(TimeSpan.FromSeconds(0.5), OnTimerTick);
        }

        private void Stop()
        {
            simplePlay.Stop();

            bStopTimer = true;
        }

        private void Pause()
        {
            simplePlay.Pause();
        }


        private string[] mp3lst()
        {
            return new string[] {
                "Sounds/Agnez Mo - Sebuah Rasa.mp3",
                "Sounds/JUNGSEUNGHWAN-THE FOOL.mp3",
                "Sounds/K.will_ Growing.mp3",
                "Sounds/Kwon Jinah-The End.mp3",
                "Sounds/Urban Zakapa_I Don't Love You.mp3"
            };
        }
               
        public MainPage()
        {
            InitializeComponent();
                                    
            PlayList();

            sliderPosition.ValueChanged += SliderPostionValueChanged;
        }
       
        private void SliderPostionValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sliderPosition.Value != simplePlay.GetPosition())
                simplePlay.SetPosition(sliderPosition.Value);
        }
       

        private void PlayList()
        {
            MusicList = new List<Music>();

            var info = mp3lst();
            for (int i = 0; i < 5; i++)
            {
                var mInfo = new Music();
                mInfo.Mp3 = info[i];
                MusicList.Add(mInfo);
            }            
        }
        
        private bool OnTimerTick()
        {
            if (!bStopTimer)
            {
                string strCurTime = simplePlay.GetCurrentTimeDisplay();
                string strTotalTime = simplePlay.GetTotalTimeDisplay();

                lblPosition.Text = strCurTime + "/" + strTotalTime;

                sliderPosition.ValueChanged -= SliderPostionValueChanged;
                sliderPosition.Value = simplePlay.GetCurrentPosition();
                sliderPosition.ValueChanged += SliderPostionValueChanged;

                if(!simplePlay.IsPlaying())
                {
                    NextPlayMusic();
                }
            }
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();                      
           
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            bStopTimer = true;

            MusicList.Clear();

        }

        private void TapGestureRecognizer_TappedimgLeft(object sender, EventArgs e)
        {
            PrePlayMusic();
        }

        private void TapGestureRecognizer_TappedimgRight(object sender, EventArgs e)
        {
            NextPlayMusic();
        }

        private void TapGestureRecognizer_TappedimgPlus(object sender, EventArgs e)
        {
            if (m_dVolume >= 1)
                m_dVolume = 1;
            else
                m_dVolume += 0.1;
            simplePlay.Volume = m_dVolume;
        }

        private void TapGestureRecognizer_TappedimgMinus(object sender, EventArgs e)
        {
            if (m_dVolume <= 0)
                m_dVolume = 0;
            else
                m_dVolume -= 0.1;
            simplePlay.Volume = m_dVolume;
        }

        private void TapGestureRecognizer_TappedimgPlay(object sender, EventArgs e)
        {
            simplePlay.Pause();
        }

        private void TapGestureRecognizer_TappedimgClose(object sender, EventArgs e)
        {
            
        }

        private void sliderVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            simplePlay.Volume = sliderVolume.Value;
        }
    }
}
