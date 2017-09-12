using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;

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

        private async void btnLoadingPopup_Clicked(object sender, EventArgs e)
        {
            await LoadingPopup.Show("LoadingPopup");

            for(int i=0; i<10; i++)
            {
                await Task.Delay(20);
            }

            await LoadingPopup.Hide();
        }

        private async void btnMessagePopupShow_Clicked(object sender, EventArgs e)
        {
            string sShow = "Show Message";
            await MessagePopup.Show($"Result: {sShow}");
        }
        
    }
}
