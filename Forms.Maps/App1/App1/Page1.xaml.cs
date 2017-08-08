using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(37.5758422, 126.971386), Distance.FromMiles(0.2)))
            {
                IsShowingUser = true, 
                MapType = MapType.Street,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
                       
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(37.5758422, 126.971386), 
                Label = "위치",
                Address = "주소"
            };
            map.Pins.Add(pin);
                        
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (s, e) => {
                var zoomLevel = e.NewValue;
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            Content = new StackLayout
            {               
                Children = { map, slider }
            };
        }
    }
}