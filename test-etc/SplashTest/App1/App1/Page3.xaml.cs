using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

            var boxViewRed = new ExBoxView
            {
                Color = Color.Red
            };
            var boxViewBlue = new ExBoxView
            {
                Color = Color.Blue
            };

            var sliderRed = new Slider
            {
                Maximum = 100,
                WidthRequest = 200,
            };
            sliderRed.PropertyChanged += (s, a) => {
                boxViewRed.Radius = (int)sliderRed.Value;
            };

            var sliderBlue = new Slider
            {
                Maximum = 100,
                WidthRequest = 200,
            };
            sliderBlue.PropertyChanged += (s, a) => {
                boxViewBlue.Radius = (int)sliderBlue.Value;
            };

            var layout = new AbsoluteLayout();
            layout.Children.Add(boxViewRed, new Point(100, 100));
            layout.Children.Add(boxViewBlue, new Point(50, 50));

            layout.Children.Add(sliderRed, new Point(50, 300));
            layout.Children.Add(sliderBlue, new Point(50, 350));


            Content = new StackLayout
            {
                BackgroundColor = Color.White,
                Children = { layout }
            };
        }
    }
}