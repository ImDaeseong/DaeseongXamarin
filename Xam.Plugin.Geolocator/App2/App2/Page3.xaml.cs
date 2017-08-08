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
    public partial class Page3 : ContentPage
    {
        string location = string.Empty;
        double lat;
        double lng;
        Geocoder geocoder;


        public Page3()
        {
            InitializeComponent();

            geocoder = new Geocoder();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var find = await FindAddress();

            /*
            var Coord = await GetCoordenadas();
            var MyAdress = await ShowMyAdress();

            lblLocation.Text = Coord;
            lblAddress.Text = MyAdress;
            */
        }

        private async void btnRefresh_Clicked(object sender, EventArgs e)
        {
            var find = await FindAddress();

            /*
            var Coord = await GetCoordenadas();
            var MyAdress = await ShowMyAdress();

            lblLocation.Text = Coord;
            lblAddress.Text = MyAdress;
            */
        }

        private async Task<bool> FindAddress()
        {
            bool bFind = true;
            try
            {
                var locator = CrossGeolocator.Current;

                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                lat = position.Latitude;
                lng = position.Longitude;

                lblLocation.Text = "Position Status: " + position.Timestamp
                        + "\nPosition Latitude: " + position.Latitude
                        + "\nPosition Longitude: " + position.Longitude;
                GetAddress();
            }
            catch 
            {
                bFind = false;
            }
            return bFind;
        }

        private async void GetAddress()
        {
            try
            {
                var positionmpla = new Position(lat, lng);
                var possibleAddresses = await geocoder.GetAddressesForPositionAsync(positionmpla);
                foreach (var address in possibleAddresses)
                {
                    lblAddress.Text += address + "\n";
                }
            }
            catch { }
        }

       
        public async Task<string> GetCoordenadas()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            return "Lat" + position.Latitude.ToString() + "Long" + position.Longitude.ToString();
        }

        public async Task<string> ShowMyAdress()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));

            return locationAddress.First().ToString();
        }

       
    }
}