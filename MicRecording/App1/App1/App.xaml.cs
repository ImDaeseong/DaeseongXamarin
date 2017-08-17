using App1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public static AudioRecorder AudioRecorder { get; set; }
        public static AudioPlayer AudioPlayer { get; set; }



        public App()
        {
            InitializeComponent();

            //MainPage = new App1.MainPage();

            //MainPage = new App1.Page1();

            AudioRecorder = DependencyService.Get<AudioRecorder>();
            AudioPlayer = DependencyService.Get<AudioPlayer>();
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
