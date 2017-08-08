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
    public partial class ReadView : ContentView
    {
        public ReadView()
        {
            InitializeComponent();
        }

       

        private async void PrePayImage_Clicked(object sender, EventArgs e)
        {
            await read.TranslateTo(-1000, 0);
            await read.FadeTo(0, 1);
            await read.TranslateTo(1000, 0);
            await read.FadeTo(1, 1);
            await read.TranslateTo(0, 0);
        }

        private async void nextplayImage_Clicked(object sender, EventArgs e)
        {
            await read.TranslateTo(1000, 0);
            await read.FadeTo(0, 1);
            await read.TranslateTo(-1000, 0);
            await read.FadeTo(1, 1);
            await read.TranslateTo(0, 0);
        }

        private async void playImage_bottom_Clicked(object sender, EventArgs e)
        {
            await read.TranslateTo(0, 0);
        }
    }
}