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
    public partial class Page3 : ContentPage
    {
        List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(200)
            {
                Label = "Label1",
                ValueLabel = "200",
                Color = SKColor.Parse("#266489")
            },
            new Microcharts.Entry(250)
            {
                Label = "Label2",
                ValueLabel = "250",
                Color = SKColor.Parse("#68B9C0")
            },
            new Microcharts.Entry(100)
            {
                Label = "Label3",
                ValueLabel = "100",
                Color = SKColor.Parse("#90D585")
            },
            new Microcharts.Entry(150)
            {
                Label = "Label4",
                ValueLabel = "150",
                Color = SKColor.Parse("#555")
            }
        };

        public Page3()
        {
            InitializeComponent();

            chart1.Chart = new Microcharts.DonutChart()
            {
                Entries = entries,
                LabelTextSize = 30,
            };
        }
    }
}