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
    public partial class AniView5 : ContentView
    {
        public AniView5()
        {
            InitializeComponent();
        }

        void Rotate_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var rotate = double.Parse(btn.CommandParameter.ToString());
            aniImg.RotateTo(rotate);
        }

        void RelRotate_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var rotate = double.Parse(btn.CommandParameter.ToString());
            aniImg.RelRotateTo(rotate);
        }
    }
}