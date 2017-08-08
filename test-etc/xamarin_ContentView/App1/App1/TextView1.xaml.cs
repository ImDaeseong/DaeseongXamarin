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
    public partial class TextView1 : ContentView
    {
        private string sText;
        private int nIndexh = 0;

        public TextView1(string sValue)
        {
            InitializeComponent();

            sText = sValue;

            Device.StartTimer(TimeSpan.FromMilliseconds(500), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            int nLen = sText.Length;
            if (nLen == nIndexh)
                nIndexh = 0;
            else
                nIndexh++;

            lblTimer.Text = sText.Substring(nIndexh);
            return true;
        }
    }
}