using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.DaeseongControl
{
    public class ImageButton :StackLayout
    {
        private Image img = new Image();
        public ImageSource Source
        {
            set { img.Source = value; }
        }

        public ImageButton()
        {
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async() => await ImageButtonClick() ),
            });
            this.Children.Add(img);
            this.Scale = .95;
        }

        private async Task ImageButtonClick()
        {
            //const Int32 ScaleTime = 25;
            //await this.ScaleTo(0.9, ScaleTime, Easing.Linear);
            //await this.ScaleTo(.95, ScaleTime, Easing.Linear);
            
            /*
            img.Opacity = 0.75;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                img.Opacity = 1;
                return false;
            });
            */

            await this.ScaleTo(0.9, 75, Easing.CubicOut);
            await this.ScaleTo(1, 75, Easing.CubicIn);
        }

    }
}
