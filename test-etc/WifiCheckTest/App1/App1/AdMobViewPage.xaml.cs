using App1.Services;
using Xamarin.Forms;

namespace App1
{
    public partial class AdMobViewPage : ContentPage
    {              
        public AdMobViewPage(string sClipboard)
        {
            InitializeComponent();

            resultLabel.Text = sClipboard;
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
