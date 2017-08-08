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
    public partial class AniView7 : ContentView
    {
        public AniView7()
        {
            InitializeComponent();
        }

        void TranslateX_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var offset = double.Parse(btn.CommandParameter.ToString());
            aniImg.TranslateTo(offset, 0);
        }

        void TranslateY_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var offset = double.Parse(btn.CommandParameter.ToString());
            aniImg.TranslateTo(0, offset);
        }
    }
}