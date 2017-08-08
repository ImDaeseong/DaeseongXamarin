using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();
                        
            if (XamarinAppSettings.BackgroundImage == "" || XamarinAppSettings.BackgroundImage == "music.png")
                splash.Source = ImageSource.FromFile("music.png");
            else
                splash.Source = ImageSource.FromFile(XamarinAppSettings.BackgroundImage);
        }

        async protected override void OnAppearing()
        {
            splash.Opacity = 0.0;
            await splash.FadeTo(1.0, 2500, Easing.SinIn);

            await Task.Delay(TimeSpan.FromSeconds(1));
            App.Current.MainPage = new MainPage();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        
    }
}