using System;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }                

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page2());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page3());
        }

    }

}
