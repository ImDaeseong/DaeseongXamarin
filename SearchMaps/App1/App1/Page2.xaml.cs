
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            CheckGeolocation();

            positionAsync();
        }

        public async Task positionAsync()
        {
            try
            {
                var locat = CrossGeolocator.Current;
                locat.DesiredAccuracy = 500;
                var position = await locat.GetPositionAsync(timeoutMilliseconds: 100000);
                MyLocation.Text = string.Format("Latitude:{0} Longitude:{1}", position.Latitude.ToString(), position.Longitude.ToString());
            }
            catch
            {
                MyLocation.Text = "positionAsync Error";
            }
        }

        public async Task CheckGeolocation()
        {
            if (!CrossGeolocator.Current.IsGeolocationAvailable)
            {
                MyGeolocationAvailable.Text = "No IsGeolocationAvailable";
            }
            else
            {
                MyGeolocationAvailable.Text = "Yes IsGeolocationAvailable";
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled)
            {
                MyGeolocationEnabled.Text = "No IsGeolocationEnabled";
            }
            else
            {
                MyGeolocationEnabled.Text = "Yes IsGeolocationEnabled";
            }
        }

    }
}