using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        TakePhotoPage takePhotoPage;

        public MainPage()
        {
            InitializeComponent();

            takePhotoPage = new TakePhotoPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (takePhotoPage.PhotoSource != null)
            {
                imgPhoto.Source = takePhotoPage.PhotoSource;
            }
        }
        protected async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(takePhotoPage);
        }


    }
}
