using System;
using Xamarin.Forms;

namespace App1.Renderers
{
    public class ExImage : Image
    {
        public event EventHandler LongPress;

        public void OnLongPress()
        {
            if (LongPress != null)
            {
                LongPress(this, new EventArgs());
            }
        }
    }
}
