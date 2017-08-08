using System;
using Xamarin.Forms;

namespace App1
{
    public class FancyFrame : Frame
    {
        public event EventHandler OnSwipe;

        public void SendSwipe()
        {
            var handler = OnSwipe;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
