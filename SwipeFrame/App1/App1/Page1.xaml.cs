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
        }

        private void swipeFrame_SwipeDown(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("swipeFrame_SwipeDown");
        }

        private void swipeFrame_SwipeTop(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("swipeFrame_SwipeTop");
        }

        private void swipeFrame_SwipeLeft(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("swipeFrame_SwipeLeft");
        }

        private void swipeFrame_SwipeRight(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("swipeFrame_SwipeRight");
        }
    }
}