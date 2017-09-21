using App1.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamd.ImageCarousel.Forms.Plugin.Abstractions;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            var images = new[] {
              new FileImageSource  { File  = "intro1.png" },
              new FileImageSource  { File  = "intro2.png" },
              new FileImageSource  { File  = "intro3.png" },
              new FileImageSource  { File  = "intro4.png" },
              new FileImageSource  { File  = "intro5.png" },
              new FileImageSource  { File  = "intro6.png" },
              new FileImageSource  { File  = "intro7.png" }
            };

            carouselImg.Images = images;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int nCurrentIndex  = carouselImg.GetSelectedIndex();
            System.Diagnostics.Debug.WriteLine(nCurrentIndex);
        }

    }
}