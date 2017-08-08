using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerView : ContentView
    {
        private void UpdateTimer()
        {
            Device.StartTimer(new TimeSpan(1000), () =>
            {
                string sText = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                displaytimer.Text = sText;
                return true;
            });
        }
        
        public TimerView()
        {
            InitializeComponent();

            BackgroundColor = Color.FromHex("#FF4081");
            
            UpdateTimer();
        }
    }
}