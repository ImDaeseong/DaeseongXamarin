using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using System.Diagnostics;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Newtonsoft.Json;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private Geocoder geocoder;

        private double Latitude;
        private double Longitude;

        public Page1()
        {
            InitializeComponent();

            geocoder = new Geocoder();

            StartTrackPosition();
            
            IsFrame(true);            
        }

        private void IsActIndicator(bool bRun)
        {
            actIndicator.IsRunning = bRun;
            actIndicator.IsVisible = bRun;
        }

        private void IsFrame(bool bVisible)
        {
            frame1.IsVisible = bVisible;
            frame2.IsVisible = !bVisible;
        }
        
        private async Task StartTrackPosition()
        {
            try
            {
                //Turn on Position tracking
                if (!CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StartListeningAsync(10000, 0);
                }
            }
            catch
            {
                Debug.WriteLine("StartTrackPosition Error");
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
                Debug.WriteLine("PositionChanged OnAppearing Error");
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
                Debug.WriteLine("OnDisappearing OnAppearing Error");
            }
        }

        private void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            try
            {
                var position = e.Position;
                var location = new Position(position.Latitude, position.Longitude);

                Latitude = position.Latitude;
                Longitude = position.Longitude;

                MyLocation.Text = string.Format("Latitude:{0} Longitude:{1}", location.Latitude, location.Longitude);

                map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));

                AddressView(position.Latitude, position.Longitude);
            }
            catch
            {
                Debug.WriteLine("CrossGeolocator_Current_PositionChanged OnAppearing Error");
            }           
        }
        
        private async void searchMe_Clicked(object sender, EventArgs e)
        {            
            IsActIndicator(true);            
            IsFrame(true);

            try
            {
                var locator = CrossGeolocator.Current;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                if (position != null)
                {
                    var location = new Position(position.Latitude, position.Longitude);

                    Latitude = position.Latitude;
                    Longitude = position.Longitude;

                    MyLocation.Text = string.Format("Latitude:{0} Longitude:{1}", location.Latitude, location.Longitude);

                    map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));

                    AddressView(position.Latitude, position.Longitude);
                }
            }
            catch
            {
                Debug.WriteLine("searchMe_Clicked OnAppearing Error");
            }

            IsActIndicator(false);
        }

        private bool PickerCompare(string sAdd)
        {
            for(int i=0; i< AddressList.Items.Count; i++)
            {
                if (sAdd == AddressList.Items[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private async void AddressView(double lat, double lng)
        {
            try
            {               
                AddressList.Items.Clear();

                Position pos = new Position(lat, lng);

                var addresses = await geocoder.GetAddressesForPositionAsync(pos);
                foreach (var list in addresses)
                {
                    if(!PickerCompare(list))
                        AddressList.Items.Add(list);
                }
            }
            catch
            {
                Debug.WriteLine("AddressView Error");
            }            
        }

        private async void searchAddress_Clicked(object sender, EventArgs e)
        {   
            IsFrame(false);

            try
            {
                string sItem = AddressList.SelectedItem.ToString();
                if (sItem == "" || sItem == null)
                {
                    var location = new Position(Latitude, Longitude);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));
                    return;
                }

                await getDataInfo(sItem);
            }
            catch
            {
                Debug.WriteLine("searchAddress_Clicked Error");
            }               
        }

        public async Task getDataInfo(string search)
        {
            IsActIndicator(true);

            mapSearch.Pins.Clear(); 

            string sInput = search;
            string sKey = "API key";
            string sWord = "search point";
            string sSearch = "";
            sSearch = sInput.Trim();
            sSearch = sInput.Replace(" ", "+");
            string url = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}+{1}&key={2}&language=ko", sWord, sSearch, sKey);
            //Debug.WriteLine(url);
                       
            var location = new Position(Latitude, Longitude);
            mapSearch.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(0.3)));
            
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response);
                //Debug.WriteLine(result.status);

                MyLocation.Text = result.status;

                if (result.status != "OK") return;
               
                foreach (var i in result.results)
                {
                    string sMap = string.Format("{0}|{1}|{2}", i.name, i.geometry.location.lat, i.geometry.location.lng);
                    Debug.WriteLine(sMap);

                    var position = new Position(i.geometry.location.lat, i.geometry.location.lng); 
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = i.name,
                        Address = i.formatted_address
                    };
                    mapSearch.Pins.Add(pin);
                }
            }

            IsActIndicator(false);

        }

    }


    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public List<object> weekday_text { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string vicinity { get; set; }
        public string formatted_address { get; set; }
    }

    public class PlacesApiQueryResponse
    {
        public List<object> html_attributions { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}