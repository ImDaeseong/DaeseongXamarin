using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        Geocoder geocoder;

        public Page4()
        {
            InitializeComponent();

            geocoder = new Geocoder();
        }

        private async Task TrackPosition()
        {
            try
            {
                //Turn on Position tracking
                if (!CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(30), 0);
                }
            }
            catch
            {
            }
        }

        public async Task<string> GetMyLocationAdress()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));
            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));
            return locationAddress.First().ToString();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;

                await TrackPosition();

                var MyAdress = await GetMyLocationAdress();
                lblAddress.Text = MyAdress;
            }
            catch
            {
            }
        }

        private async void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            try
            {
                var position = e.Position;
                var location = new Position(position.Latitude, position.Longitude);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));

                var MyAdress = await GetMyLocationAdress();
                lblAddress.Text = MyAdress;
            }
            catch
            {
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
            }
            catch
            {
            }
        }

        private async void btnRefresh_Clicked(object sender, EventArgs e)
        {
            try
            {
                var MyAdress = await GetMyLocationAdress();
                lblAddress.Text = MyAdress;
            }
            catch
            {
            }
        }
    }
}