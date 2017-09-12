using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPopup : PopupPage
    {
        public LoadingPopup(string sMessage)
        {
            InitializeComponent();
            this.message.Text = sMessage;
        }

        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }
        
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        public static async Task Show(string sMessage)
        {
            await PopupNavigation.PushAsync(new LoadingPopup(sMessage));
        }

        public static async Task Hide()
        {
            await PopupNavigation.PopAsync();
        }

        private void OnClose(object sender, EventArgs e)
        {

        }
    }
}