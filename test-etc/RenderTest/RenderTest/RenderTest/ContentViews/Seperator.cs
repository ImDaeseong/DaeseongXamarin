using Xamarin.Forms;

namespace RenderTest.ContentViews
{
    public class Seperator : BoxView
    {
        public Seperator()
        {
            Color = Color.Gray;
            HeightRequest = 0.5;

            LineSeperatorView = new BoxView()
            {
                Color = Color.FromHex("#D0D1D7"),
                WidthRequest = 100,
                HeightRequest = 1
            };
        }
        public BoxView LineSeperatorView { get; set; }
    }

}
