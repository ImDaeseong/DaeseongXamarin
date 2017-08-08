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
    public partial class AniView6 : ContentView
    {
        public AniView6()
        {
            InitializeComponent();
        }

        void Scale_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var scale = double.Parse(btn.CommandParameter.ToString());
            aniImg.ScaleTo(scale);
        }

        void ReScale_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var scale = double.Parse(btn.CommandParameter.ToString());
            aniImg.RelScaleTo(scale);
        }
    }
}