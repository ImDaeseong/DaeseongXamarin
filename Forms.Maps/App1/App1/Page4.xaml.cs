using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(37.5758422, 126.971386), Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var position1 = new Position(37.5758422, 126.971386);
            var position2 = new Position(36.5758422, 126.971386);
            var position3 = new Position(35.5758422, 126.971386);
            var position4 = new Position(34.5758422, 126.971386);
            var position5 = new Position(33.5758422, 126.971386);
            var position6 = new Position(32.5758422, 126.971386);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "37.5758422, 126.971386",
                Address = "37.5758422, 126.971386",
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "36.5758422, 126.971386",
                Address = "36.5758422, 126.971386"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "35.5758422, 126.971386",
                Address = "35.5758422, 126.971386"
            };

            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = position4,
                Label = "34.5758422, 126.971386",
                Address = "34.5758422, 126.971386"
            };

            var pin5 = new Pin
            {
                Type = PinType.Place,
                Position = position5,
                Label = "33.5758422, 126.971386",
                Address = "33.5758422, 126.971386"
            };

            var pin6 = new Pin
            {
                Type = PinType.Place,
                Position = position6,
                Label = "32.5758422, 126.971386",
                Address = "32.5758422, 126.971386"
            };

            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);
            map.Pins.Add(pin4);
            map.Pins.Add(pin5);
            map.Pins.Add(pin6);

            Content = map;
        }
    }
}