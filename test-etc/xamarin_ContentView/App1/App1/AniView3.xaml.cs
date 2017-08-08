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
    public partial class AniView3 : ContentView
    {
        public AniView3()
        {
            InitializeComponent();
        }

        void AniX_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var flip = double.Parse(btn.CommandParameter.ToString());
            aniImg.RotateXTo(flip);
        }

        void AniY_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var flip = double.Parse(btn.CommandParameter.ToString());
            aniImg.RotateYTo(flip);
        }
    }
}