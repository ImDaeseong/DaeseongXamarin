using RenderTest.ActivityIndicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RenderTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        LoadingIndicator Loadertor;

        public Page4()
        {
            InitializeComponent();

            Button b1 = new Button();
            b1.Text = "IsShowLoading true";
            b1.Clicked += ShowLoading_Clicked;

            Button b2 = new Button();
            b2.Text = "IsShowLoading false";
            b2.Clicked += HideLoading_Clicked;


            Loadertor = new ActivityIndicators.LoadingIndicator();
            StackLayout slLayout = new StackLayout
            {
                Children =
                    {
                       b1,  b2, Loadertor
                    },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            slLayout.Padding = new Thickness(0, 5, 0, 0);

            Content = slLayout;

        }

        private void ShowLoading_Clicked(object sender, EventArgs e)
        {
            Loadertor.IsShowLoading = true;
        }

        private void HideLoading_Clicked(object sender, EventArgs e)
        {
            Loadertor.IsShowLoading = false;
        }

       
    }
}