using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{    
    public partial class Notificacion : PopupPage
    {
        public Notificacion(string sText1, string sText2)
        {
            InitializeComponent();
            //lblText1.Text = sText1;
            //lblText2.Text = sText2;
        }

        protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}