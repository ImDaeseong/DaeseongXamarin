using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App3.DaeseongControl
{
    public class TextTicker : StackLayout
    {
        public bool On { get; set; }


        int nIndex = 0;
        List<TextMarquess> lstText;

        Label contentLabel;

        public TextTicker()
        {
            this.VerticalOptions = LayoutOptions.Start;
            this.HorizontalOptions = LayoutOptions.CenterAndExpand;

            contentLabel = new Label
            {
                FontSize = 12,
                TextColor = Color.LightPink,
                VerticalOptions = LayoutOptions.Center,
            };

            BackgroundColor = Color.Transparent;
            Children.Add(contentLabel);

            lstText = new List<TextMarquess>
            {
                new TextMarquess { DisplayText = DateTime.Now.ToString("hh : mm"), DisplayColor = Color.Orange },
                new TextMarquess { DisplayText = DateTime.Now.ToString("hh : mm"), DisplayColor = Color.OrangeRed }
            };
        }

        public void Run()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (!On || lstText.Count == 0) return false;

                contentLabel.Text = lstText[nIndex].DisplayText;
                contentLabel.TextColor = lstText[nIndex].DisplayColor;
                nIndex++;

                if (nIndex == lstText.Count)
                    nIndex = 0;

                return On;
            });
        }

    }

    public class TextMarquess
    {
        public string DisplayText { get; set; }
        public Color DisplayColor { get; set; }
    }
}
