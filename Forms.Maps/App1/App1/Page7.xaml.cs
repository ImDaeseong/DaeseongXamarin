using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;


namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page7 : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();

        public Page7()
        {
            InitializeComponent();

            searchBar.Text = "덕수궁";
            SearchBar_SearchButtonPressed(null, null);
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
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