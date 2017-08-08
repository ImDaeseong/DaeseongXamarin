using System;
using Xamarin.Forms;

namespace App3.DaeseongControl
{
    public  class Ticker : StackLayout
    {
        TimeSpan ts;

        Label contentLabel;
        string sContent { get; set; }
        
        public String Content
        {
            get
            {
                return sContent;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    sContent = value.Replace("\n", " ");
                    contentLabel.Text = sContent;
                }
            }
        }

        public Ticker()
        {
            contentLabel = new Label
            {
                FontSize = 12,
                TextColor = Color.Orange,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            IsVisible = false;
            BackgroundColor = Color.Transparent;
            Children.Add(contentLabel);

            ts = TimeSpan.FromSeconds(0.5);
        }

        public void Run(bool bOn)
        {
            IsVisible = bOn;

            Device.StartTimer(ts, () =>
            {
                if (!bOn || string.IsNullOrEmpty(Content))
                    return false;

                Content = Content.Substring(1) + Content.Substring(0, 1);

                return bOn;
            });
        }

    }

}
