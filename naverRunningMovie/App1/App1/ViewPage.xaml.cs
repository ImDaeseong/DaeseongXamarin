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
    public partial class ViewPage : ContentPage
    {
        public ViewPage(Movie item)
        {
            InitializeComponent();

            Movie itemDetail = (Movie)item;

            lbltitle.Text = itemDetail.Title;
            imgImage.Source = itemDetail.ImageUrl;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}