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
    public partial class AniView2 : ContentView
    {
        public AniView2()
        {
            InitializeComponent();
        }

        void Ani_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;

            var fate = double.Parse(btn.CommandParameter.ToString());
            aniImg.FadeTo(fate, 2000);
        }
    }
}