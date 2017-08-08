using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturePage : ContentPage
    {
        private string imagePath;

        public PicturePage()
        {
            InitializeComponent();

            BackgroundColor = Color.FromHex("#253648");
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (XamarinAppSettings.PageName != "PicturePage")
                    XamarinAppSettings.PageName = "PicturePage";
            }
            catch
            {
                App.WriteString("PicturePage OnAppearing Failed");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.CurrentIndex = 3;
            XamarinAppSettings.PageName = "PicturePage";
        }

        private async void btnTakePicture_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    return;

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "photo",
                    Name = "bg.jpg",
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;

                imagePath = file.Path;

                bgImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                
                if(imagePath != "")
                    XamarinAppSettings.BackgroundImage = imagePath;
            }
            catch
            {
                App.WriteString("PicturePage btnTakePicture_Clicked Failed");
            }
        }

        private async void btnPickPicture_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                    return;

                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {                   
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;

                imagePath = file.Path;

                bgImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                if (imagePath != "")
                    XamarinAppSettings.BackgroundImage = imagePath;                
            }
            catch
            {
                App.WriteString("PicturePage btnPickPicture_Clicked Failed");
            }
        }

        private void btnCanelPickPicture_Clicked(object sender, EventArgs e)
        {
            bgImage.Source = "musiclist.png";

            XamarinAppSettings.BackgroundImage = "";
        }
    }
}