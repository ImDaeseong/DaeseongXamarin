using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();

            AnimatedButton aniBtn = new AnimatedButton("AnimatedButton")
            {
                BackgroundColor = Color.Orange,
                TextColor = Color.White,
                Padding = 5,
                WidthRequest = 100,
                HeightRequest = 40,
            };
            xAniButton.Children.Add(aniBtn);
        }

        private async void AButton_Clicked(object sender, EventArgs e)
        {
            var page = new Notificacion("sText1", "sText2");
            
            await Navigation.PushPopupAsync(page);
            // or
            //await PopupNavigation.PushAsync(page);
        }
    }
}