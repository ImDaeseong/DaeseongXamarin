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
    public partial class TimeView2 : ContentView
    {
        public TimeView2()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("T");
            lblDate.Text = dt.ToString("D");
            return true;
        }
    }
}