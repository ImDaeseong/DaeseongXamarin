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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            
            WidgetTimer.Children.Add(new TimeView1());
            WidgetTimer.Children.Add(new TimeView2());
            WidgetTimer.Children.Add(new TextView1("abcdefghijklmnopqrstuvwxyz"));
            WidgetTimer.Children.Add(new TextView2());
            WidgetTimer.Children.Add(new TextView3());
            WidgetTimer.Children.Add(new TextView4("abcdefghijklmnopqrstuvwxyz"));
            WidgetTimer.Children.Add(new TextView5("abcdefghijklmnopqrstuvwxyz"));            
        }

    }
}