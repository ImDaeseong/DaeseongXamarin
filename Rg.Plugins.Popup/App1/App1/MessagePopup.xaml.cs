using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePopup : PopupPage
    {
        public MessagePopup(string sMessage)
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
               
        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        public static async Task Show(string sMessage)
        {
            await PopupNavigation.PushAsync(new MessagePopup(sMessage));
        }

    }
}