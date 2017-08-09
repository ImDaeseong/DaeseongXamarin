using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class TextSpinClass
    {
        public string LineOfText { get; set; }

        public Color ColorOfText { get; set; }
    }

    public partial class App : Application, INotifyPropertyChanged
    {
        public static App Self { get; private set; }

        //public string Url { get; private set; } = "https://www.google.co.kr/images/branding/product/ico/googleg_lodp.ico";
        public string Url { get; private set; } = "http://www.iloveimg.com/images/favicons/favicon-16x16.png";


        public long DownloadTotal { get; set; } = 1;



        int downloadProgress;
        public int DownloadProgress
        {
            get { return downloadProgress; }
            set
            {
                downloadProgress = value;
                OnPropertyChanged("DownloadProgress");
            }
        }



        bool downloadCompleted;
        public bool DownloadCompleted
        {
            get
            {
                return downloadCompleted;
            }
            set
            {
                downloadCompleted = value;
                OnPropertyChanged("DownloadCompleted");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public App()
        {
            InitializeComponent();
            
            //MainPage = new App1.MainPage();
            //MainPage = new App1.Page1();

            //download test
            App.Self = this;
            MainPage = new App1.Page2();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
