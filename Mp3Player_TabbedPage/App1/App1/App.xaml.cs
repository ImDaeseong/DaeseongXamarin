using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {

        public static void WriteString(string sText)
        {
            DependencyService.Get<ILogFile>().WriteString(sText);
        }

        public static bool LoadMusicPage
        {
            get;
            set;
        }

        public static int CurrentIndex
        {
            get;
            set;
        }

        static bool bSplah = false;

        public App()
        {
            InitializeComponent();
            
            //WriteString("App Start");
            
            if (bSplah)
                MainPage = new App1.MainPage();
            else
            {
                bSplah = true;
                MainPage = new App1.Splash();
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            
        }       
    }
}
