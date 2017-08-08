using Xamarin.Forms;

namespace RenderTest.ContentViews
{
    public class TitleBar : ContentView
    {
        public TitleBar()
        {
            Padding = new Thickness(5, 5, 5, 5);
            HorizontalOptions = LayoutOptions.StartAndExpand;
            Content = new Xamarin.Forms.Label
            {
                Text = "제목바",
                FontSize = 15,
                FontAttributes = Xamarin.Forms.FontAttributes.Bold,
                TextColor = Color.FromHex("#E47911")
            };
        }

        public TitleBar(string title)
        {
            Padding = new Thickness(5, 5, 5, 5);
            HorizontalOptions = LayoutOptions.StartAndExpand;
            Content = new Xamarin.Forms.Label
            {
                Text = title,
                FontSize = 15,
                FontAttributes = Xamarin.Forms.FontAttributes.Bold,
                TextColor = Color.FromHex("#E47911")
            };
        }

        public TitleBar(string title, bool isClickable = false)
        {
            Padding = new Thickness(5, 5, 5, 5);
            HorizontalOptions = LayoutOptions.StartAndExpand;

            Xamarin.Forms.Label lblTitlebar = new Label();
            lblTitlebar.Text = title;
            lblTitlebar.FontSize = 15;

            if (isClickable)
            {
                lblTitlebar.TextColor = Color.FromHex("#3366AA");
            }
            else
            {
                lblTitlebar.TextColor = Color.FromHex("#E47911"); 
            }

            Content = lblTitlebar;
        }

        public TitleBar(string title, int fontSize, Color textColor, Thickness padding)
        {
            Padding = padding;
            HorizontalOptions = LayoutOptions.StartAndExpand;
            Content = new Xamarin.Forms.Label
            {
                Text = title,
                FontSize = fontSize,
                TextColor = textColor
            };
        }
    }
}
