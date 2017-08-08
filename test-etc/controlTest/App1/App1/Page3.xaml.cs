using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

            SwipeableImage.SwipedUp += (sender, args) => { DirectionInfo.Text = "UP"; };
            SwipeableImage.SwipedDown += (sender, args) => { DirectionInfo.Text = "DOWN"; };
            SwipeableImage.SwipedLeft += (sender, args) => { DirectionInfo.Text = "LEFT"; };
            SwipeableImage.SwipedRight += (sender, args) => { DirectionInfo.Text = "RIGHT"; };
        }
    }
}