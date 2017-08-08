using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        string searchBar = "덕수궁";
        public Page5()
        {
            InitializeComponent();

            Mapsview.Children.Add(new MapView(searchBar));
        }
    }
}