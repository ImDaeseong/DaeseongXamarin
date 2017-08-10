using Xamarin.Forms;

namespace App1.Controls
{
    public class EmptyLabel : Label
    {
        public EmptyLabel()
        {
            TextColor = Color.White;
            Text = "EmptyLabel";
            HorizontalOptions = LayoutOptions.Center;
            HorizontalTextAlignment = TextAlignment.Center;
            VerticalTextAlignment = TextAlignment.Center;
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(this, new Rectangle(.5, .5, 400, 300));
        }
    }
}
