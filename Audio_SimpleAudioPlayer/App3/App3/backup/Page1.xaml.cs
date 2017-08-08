using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private clsSimpleAudio simplePlay = clsSimpleAudio.getInstance;


        private int CurrentPlayIndex = -1;

        public ObservableCollection<MusicModel> MusicSource { get; set; }
        

        private async Task LoadMusic()
        {
            MusicSource.Add(
                new MusicModel()
                {
                    Name = "Sounds/Agnez Mo - Sebuah Rasa.mp3",
                    Artist = "Agnez Mo",
                    Album = "Agnez Mo",
                });

            MusicSource.Add(
            new MusicModel()
                {
                    Name = "Sounds/JUNGSEUNGHWAN-THE FOOL.mp3",
                    Artist = "JUNGSEUNGHWAN",
                    Album = "JUNGSEUNGHWAN",
            });

            MusicSource.Add(
            new MusicModel()
                {
                    Name = "Sounds/K.will_ Growing.mp3",
                    Artist = "K.will",
                    Album = "K.will",
            });

            MusicSource.Add(
            new MusicModel()
                 {
                     Name = "Sounds/Kwon Jinah-The End.mp3",
                     Artist = "Kwon Jinah",
                     Album = "Kwon Jinah",
            });

            MusicSource.Add(
            new MusicModel()
                 {
                     Name = "Sounds/Urban Zakapa_I Don't Love You.mp3",
                     Artist = "Urban Zakapa",
                     Album = "Urban Zakapa",
            });

            await DisplayAlert("", "Load Music", "OK");
        }


        public Page1()
        {
            InitializeComponent();

            MusicSource = new ObservableCollection<MusicModel>();

            Task.Factory.StartNew(() => LoadMusic());

            BindingContext = this;
            
        }
        

        private void TapGestureRecognizer_TappedPrePlayMusic(object sender, EventArgs e)
        {
            if (MusicSource.Count == 0) return;

            CurrentPlayIndex--;

            if (CurrentPlayIndex < 0)
                CurrentPlayIndex = MusicSource.Count - 1;

            Play(MusicSource[CurrentPlayIndex]);

        }

        private void TapGestureRecognizer_TappedPlay(object sender, EventArgs e)
        {
            if (simplePlay.IsPlaying())
                simplePlay.Pause();
            else
                simplePlay.Play();
        }

        private void TapGestureRecognizer_TappedNextPlayMusic(object sender, EventArgs e)
        { 
            if (MusicSource.Count == 0) return;

            CurrentPlayIndex++;

            if (CurrentPlayIndex > (MusicSource.Count - 1))
                CurrentPlayIndex = 0;

            Play(MusicSource[CurrentPlayIndex]);
        }

        private void Play(MusicModel item)
        {
            if (MusicSource.Count == 0) return;

            CurrentPlayIndex = MusicSource.IndexOf(item);

            Debug.WriteLine(CurrentPlayIndex.ToString());

            if (simplePlay.IsPlaying())
                simplePlay.Stop();

            simplePlay.Open(item.Name);
            simplePlay.Play();                    
                        
            totalTime.Text = simplePlay.GetTotalTimeDisplay();

            Device.StartTimer(new TimeSpan(1000), () =>
            {
                progress.Progress = simplePlay.GetCurrentPosition() * 1.0f / simplePlay.GetPosition();

                currentTime.Text = simplePlay.GetCurrentTimeDisplay();

                bool bPlay = simplePlay.IsPlaying();
                if (!bPlay)
                {          
                    CurrentPlayIndex = 0;
                    Play(MusicSource[CurrentPlayIndex]);
                }
                return bPlay;
            });
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                (sender as ListView).SelectedItem = null;
                var model = e.SelectedItem as MusicModel;
                if (MusicSource.IndexOf(model) == CurrentPlayIndex)
                    return;
                
                Play(model);
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var model = (MusicModel)e.Item;
            if (MusicSource.IndexOf(model) == CurrentPlayIndex)
                return;
                        
            Play(model);
        }
    }

    public class MusicModel
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public MusicModel()
        {
        }
    }

}
