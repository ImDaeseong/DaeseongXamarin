using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnok_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popup());
        }
    }
}
