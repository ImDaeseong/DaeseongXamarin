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
    public partial class AniView4 : ContentView
    {
        public AniView4()
        {
            InitializeComponent();
        }

        async void Ani_Clicked(object sender, System.EventArgs e)
        {
            await aniImg.ScaleTo(0.3, 500);
            await aniImg.RotateYTo(90, 500);
            aniImg.Source = "a.jpg";
            await aniImg.RotateYTo(180, 500);
            await aniImg.ScaleTo(1, 500);
            await aniImg.FadeTo(0, 500);
        }

    }
}