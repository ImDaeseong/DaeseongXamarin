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
    public partial class AniView1 : ContentView
    {
        public AniView1()
        {
            InitializeComponent();
        }

        void Ani_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Text == "Ani1")
            {
                aniImg.LayoutTo(new Rectangle() { X = aniImg.X, Y = aniImg.Y, Width = 300, Height = aniImg.Height }, 1000);
            }
            else if (btn.Text == "Ani2")
            {
                aniImg.LayoutTo(new Rectangle() { X = aniImg.X, Y = aniImg.Y, Width = 400, Height = aniImg.Height }, 1000);
            }
            else if (btn.Text == "Ani3")
            {
                aniImg.LayoutTo(new Rectangle() { X = aniImg.X, Y = aniImg.Y, Width = 500, Height = aniImg.Height }, 1000);
            }
            else if (btn.Text == "Ani4")
            {
                aniImg.LayoutTo(new Rectangle() { X = aniImg.X, Y = aniImg.Y, Width = 600, Height = aniImg.Height }, 1000);
            }
        }

    }
}