using App1.Services;
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        private ToSpeak TextToSpeech = ToSpeak.getInstance;

        public App()
        {
            InitializeComponent();
            
            MainPage = new App1.Page1();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            TextToSpeech.InitSpeak();
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
