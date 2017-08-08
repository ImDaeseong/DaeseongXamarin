using RenderTest.ActivityIndicators;
using RenderTest.ContentViews;
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
    public partial class Page3 : ContentPage
    {

        LoadingIndicator Loadertor;

        public Page3()
        {
            InitializeComponent();
                        
            /*
            TitleBar tb = new TitleBar("제목바", true);
            StackLayout sltb = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 5, 0, 0),
                BackgroundColor = Color.FromHex("#E47911"),
                Children = { tb }
            };

            Seperator sp = new Seperator();
                      
            this.Content = new StackLayout
            {
                Children = { sltb, sp.LineSeperatorView, f1, f2, sSeperator },
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White
            };
            */
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            f1.IsVisible = false;
        }
        
        private void Add1_Clicked(object sender, EventArgs e)
        {
            f2.IsVisible = false;
        }

       
    }
}