using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page7 : ContentPage
    {
        public List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
               Label="Label1",
               ValueLabel="200",
               Color=SKColors.Coral,
               TextColor=SKColors.Coral
            },
            new Entry(100)
            {
                Label="Label2",
                ValueLabel="100",
                Color=SKColors.Black,
                TextColor=SKColors.Black
            },
            new Entry(-100)
            {
                Label="Label3",
                ValueLabel="-100",
                Color=SKColors.Green,
                TextColor=SKColors.Green
            },
            new Entry(300)
            {
                Label="Label4",
                ValueLabel="300",
                Color=SKColors.Chocolate,
                TextColor=SKColors.Chocolate
            },
            new Entry(134)
            {
                Label="Label5",
                ValueLabel="134",
                Color=SKColors.AliceBlue,
                TextColor=SKColors.AliceBlue
            },
            new Entry(368)
            {
                Label="Label6",
                ValueLabel="368",
                Color=SKColors.AntiqueWhite,
                TextColor=SKColors.AntiqueWhite
            },
            new Entry(125)
            {
                Label="Julio",
                ValueLabel="125",
                Color=SKColors.Cornsilk,
                TextColor=SKColors.Cornsilk
            },
            new Entry(175)
            {
                Label="Label7",
                ValueLabel="175",
                Color=SKColors.DarkViolet,
                TextColor=SKColors.DarkViolet
            },
            new Entry(189)
            {
                Label="Label8",
                ValueLabel="189",
                Color=SKColors.LemonChiffon,
                TextColor=SKColors.LemonChiffon
            }
        };


        public Page7()
        {
            InitializeComponent();

            chart1.Chart = new RadialGaugeChart { Entries = entries };
            chart2.Chart = new PointChart { Entries = entries };
            chart3.Chart = new DonutChart { Entries = entries };
            chart4.Chart = new BarChart { Entries = entries };
            chart5.Chart = new LineChart { Entries = entries, PointSize = 10, LabelTextSize = 17, LineSize = 3, PointMode = PointMode.Circle, LineMode = LineMode.Straight };

        }
    }
}