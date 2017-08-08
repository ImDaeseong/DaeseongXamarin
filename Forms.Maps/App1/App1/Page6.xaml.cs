using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page6 : ContentPage
    {
        private SearchBar searchBar;
        private Map map;
        private readonly Geocoder geocoder = new Geocoder();

        public Page6()
        {
            InitializeComponent();

            searchBar = new SearchBar()
            {
                Placeholder = "Search",
            };

            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 300,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var stack = new StackLayout();
            stack.Padding = new Thickness(20);
            stack.Spacing = 20;
            stack.Orientation = StackOrientation.Vertical;

            stack.Children.Add(searchBar);
            stack.Children.Add(map);
            Content = stack;

            searchBar.SearchButtonPressed += OnSearchButtonPressed;


            searchBar.Text = "덕수궁";
            OnSearchButtonPressed(null, null);
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var positions = await geocoder.GetPositionsForAddressAsync(searchBar.Text);
            var position = positions.FirstOrDefault();
            if (position != null)
            {
                map.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        position,
                        Distance.FromMiles(0.2)));

                var addresses = await geocoder.GetAddressesForPositionAsync(position);

                var address = addresses.FirstOrDefault();

                if (address != null)
                {
                    map.Pins.Clear();

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = searchBar.Text,
                        Address = address.Replace("\n", "")
                    };
                    map.Pins.Add(pin);
                }
            }
        }

    }
}