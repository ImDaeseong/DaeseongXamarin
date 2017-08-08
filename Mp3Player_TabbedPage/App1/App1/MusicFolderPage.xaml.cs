using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicFolderPage : ContentPage
    {
        private clsSimpleAudio simplePlay = clsSimpleAudio.getInstance;
        private List<MusicFolder> musicFolder;
        private bool isReady;
       
        public MusicFolderPage()
        {
            InitializeComponent();
            
            try
            {
                BackgroundColor = Color.FromHex("#FF4081");

                musicFolder = null;
                musicFolder = new List<MusicFolder>();
                MusicFolderList.ItemsSource = musicFolder;
                MusicFolderList.ItemTapped += MusicFolderList_ItemTapped;
                
                LoadData();
            }
            catch 
            {
                App.WriteString("MusicFolderPage MusicFolderPage Failed");
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
                var observableCollection = simplePlay.GetDirectorys();
                foreach (string item in observableCollection)
                {
                    musicFolder.Add(new MusicFolder(item.ToString(), "foldermusic.png"));
                    Task.Delay(TimeSpan.FromMilliseconds(22));
                }
                isReady = true;
            });
        }
                        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (XamarinAppSettings.PageName != "MusicFolderPage")
                    XamarinAppSettings.PageName = "MusicFolderPage";               
            }
            catch 
            {
                App.WriteString("MusicFolderPage OnAppearing Failed");
            }
        }
                        
        private void MusicFolderList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item == null || !isReady) return;  
                           
                var Music = (MusicFolder)e.Item;
                int CurrentPlayIndex = musicFolder.IndexOf(Music);
                                
                if (!App.LoadMusicPage)
                {
                    App.LoadMusicPage = true;
                    Navigation.PushModalAsync(new MusicList(Music.sName), true);                    
                }
                ((ListView)sender).SelectedItem = null;
            }
            catch 
            {
                App.WriteString("MusicFolderPage MusicFolderList_ItemTapped Failed");
            }
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            try
            {               
                App.CurrentIndex = 0;
                XamarinAppSettings.PageName = "MusicFolderPage";
            }
            catch
            {
                App.WriteString("MusicFolderPage OnDisappearing Failed");
            }
        }

    }

    class MusicFolder
    {
        public string sName { get; set; }
        public string sImage { get; set; }
        
        public MusicFolder(string Name, string Image)
        {
            this.sName = Name;
            this.sImage = Image;
        }
    }
}