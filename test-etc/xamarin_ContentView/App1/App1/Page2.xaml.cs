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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            WidgetTimer.Children.Add(new AniView7());
            WidgetTimer.Children.Add(new AniView6());
            WidgetTimer.Children.Add(new AniView5());
            WidgetTimer.Children.Add(new AniView4());
            WidgetTimer.Children.Add(new AniView3());
            WidgetTimer.Children.Add(new AniView2());
            WidgetTimer.Children.Add(new AniView1());
        }
    }
}