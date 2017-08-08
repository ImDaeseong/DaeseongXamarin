using App1.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void ExImage_LongPress(object sender, EventArgs e)
        {
            DisplayAlert("", "Long Press", "OK");
        }
    }
}