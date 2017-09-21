using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
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
    }
}