using App2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        private IWallPaper wallPaper;

        public MainPage()
        {
            InitializeComponent();

            wallPaper = DependencyService.Get<IWallPaper>();
        }

        private void Buttonwallpaper_Clicked(object sender, EventArgs e)
        {
            wallPaper.SetChangeWallPaperImage();
        }             

    }
}
