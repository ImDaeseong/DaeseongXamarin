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
    public partial class TextView5 : ContentView
    {
        private int currentPos = 0;
        private string sText;

        public TextView5(string sValue)
        {
            InitializeComponent();

            sText = sValue;

            lblText.Text = sText;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), OnTimerTick);
            currentPos = sText.Length;
        }

        private bool OnTimerTick()
        {
            if (currentPos < 1)
            {
                lblText.Text = sText;
                currentPos = sText.Length;
                return true;
            }

            currentPos--;
            if (currentPos > 1)
                lblText.Text = sText.Substring(0, currentPos - 1);
            else
            {
                lblText.Text = "";
            }

            return true;
        }

    }
}