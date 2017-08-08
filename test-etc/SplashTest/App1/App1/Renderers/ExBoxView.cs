using Xamarin.Forms;

namespace App1.Renderers
{
    public class ExBoxView : BoxView
    {
        public int ShadowSize { get; set; } 

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create<ExBoxView, int>(p => p.Radius, 20);
        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public ExBoxView()
        {
            Radius = 10;
            ShadowSize = 5;
            WidthRequest = 150;
            HeightRequest = 150;
        }
    }
}
