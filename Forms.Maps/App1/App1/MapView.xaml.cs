using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentView
    {
        Map map;

        public MapView(String address)
        {
            InitializeComponent();
                        
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 300,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };

            GetLocation(address);
            //GetLocation(address, address);

            stack.Children.Add(map);
        }

        private async void GetLocation(String address)
        {
            var geoCoder = new Geocoder();
            var positions = (await geoCoder.GetPositionsForAddressAsync(address)).ToList();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions[0], Distance.FromKilometers(0.3)));
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = positions[0],
                Label = address
            };
            map.Pins.Add(pin);
        }

        private async void GetLocation(string addr, string name)
        {
            Geocoder gc = new Geocoder();
            Task<IEnumerable<Position>> result = gc.GetPositionsForAddressAsync(addr);

            IEnumerable<Position> data = await result;

            foreach (Position p in data)
            {
                map.MoveToRegion(new MapSpan(p, .5, .5));
                map.Pins.Add(new Pin() { Address = addr, Label = name, Position = new Position(p.Latitude, p.Longitude) });
            }
        }

    }
}