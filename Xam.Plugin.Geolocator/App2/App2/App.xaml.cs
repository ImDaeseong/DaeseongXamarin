using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new App2.MainPage();
            //MainPage = new App2.Page1();
            //MainPage = new App2.Page2();
            //MainPage = new App2.Page3();
            MainPage = new App2.Page4();
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
