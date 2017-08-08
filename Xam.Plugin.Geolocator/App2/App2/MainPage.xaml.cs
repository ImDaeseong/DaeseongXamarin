using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        Map map;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MapSpan initialSpan = new MapSpan(LocationHandler.Instance.CurrentLocation, 360, 360);
            map = new Map(initialSpan);

            System.Diagnostics.Debug.WriteLine(string.Format("Current Location {0} , {1}", LocationHandler.Instance.CurrentLocation.Latitude, LocationHandler.Instance.CurrentLocation.Longitude));
                        
        }

        private async void Refresh()
        {
            await LocationHandler.Instance.GetLocation();
        }
    }
}
