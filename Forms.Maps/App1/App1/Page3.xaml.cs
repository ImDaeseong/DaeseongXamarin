using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

            var centerPosition = new Position(37.5758422, 126.971386);

            var distanceFromCenter = Distance.FromKilometers(0.5);

            var mapSpan = MapSpan.FromCenterAndRadius(centerPosition, distanceFromCenter);

            var map = new CustomMap(mapSpan);

            Content = map;
        }
    }
}