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
    public partial class TextView4 : ContentView
    {
        private int currentPos = 0;
        private string sText;


        public TextView4(string sValue)
        {
            InitializeComponent();

            sText = sValue;

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            if (currentPos > sText.Length)
            {
                currentPos = 0;
                lblText.Text = "";
                return true;
            }

            currentPos++;
            if (currentPos > 1)
                lblText.Text = sText.Substring(0, currentPos - 1);
            else
                lblText.Text = "";

            return true;
        }

    }
}