using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            Refresh.Clicked += async (sender, args) =>
            {
                try
                {
                    var locator = CrossGeolocator.Current;

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                    if (position == null)
                    {
                        return;
                    }
                    var location = new Position(position.Latitude, position.Longitude);

                    //Set your location for others to find!
                    double  Latitude = position.Latitude;
                    double  Longitude = position.Longitude;
                    DateTimeOffset TimeStamp = position.Timestamp;
                    
                    //Show your location
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Uh oh", "Something went wrong, but don't worry", "OK");
                }
            };

            TrackPosition();
        }

        private async Task TrackPosition()
        {
            try
            {
                //Turn on Position tracking
                if (!CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(10), 0);
                }
            }
            catch
            {
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
            }
            catch
            {
            }
        }

        void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;
            var location = new Position(position.Latitude, position.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));
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

    }
}