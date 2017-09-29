using Xamarin.Forms;
using App1.Services;

namespace App1
{
    public partial class AdMobViewPage : ContentPage
    {
        private string sHtml;
        public string GetHtml
        {
            get { return sHtml; }
            set
            {
                sHtml = value;
                resultLabel.Text = sHtml;

                DisplayAlert("Html", sHtml, "OK");
            }
        }

        public AdMobViewPage()
        {
            InitializeComponent();
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            //

        }

        protected override void OnDisappearing()
        {
            //


            base.OnDisappearing();
        }

    }
}
