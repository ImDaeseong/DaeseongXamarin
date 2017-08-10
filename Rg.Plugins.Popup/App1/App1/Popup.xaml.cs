using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

namespace App1
{   
    public partial class Popup : PopupPage
    {
        public Popup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //HidePopup();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }

        private async void HidePopup()
        {
            await Task.Delay(4000);
            await PopupNavigation.RemovePageAsync(this);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}