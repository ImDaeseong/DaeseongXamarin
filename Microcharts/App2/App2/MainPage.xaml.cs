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
        public MainPage()
        {
            InitializeComponent();
        }

        private void page1Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }

        private void page2Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page2());
        }

        private void page3Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page3());
        }

        private void page4Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page4());
        }

        private void page5Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page5());
        }

        private void page6Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page6());
        }

        private void page7Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page7());
        }

    }
}
