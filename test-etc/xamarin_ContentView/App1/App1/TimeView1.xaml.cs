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
    public partial class TimeView1 : ContentView
    {
        public TimeView1()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                lblTimer.Text = DateTime.Now.ToString("T");
                return true;
            });
        }

        private void lblTimer_SizeChanged(object sender, EventArgs e)
        {
            lblTimer.FontSize = Width / 6;
        }
    }
}