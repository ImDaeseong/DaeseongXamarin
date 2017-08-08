using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            WidgetTimer.Children.Add( new TimerView() );           
            WidgetTimer.Children.Add( new RotationView() );
            WidgetTimer.Children.Add(new ImgView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
