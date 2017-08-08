using Android.Views;
using App1.Renderers;

namespace App1.Droid.Renderers
{
    internal class MyGestureListener : GestureDetector.SimpleOnGestureListener
    {
        public ExImage ExImage { private get; set; } 
        
        public override void OnLongPress(MotionEvent e)
        {
            base.OnLongPress(e);
            if (ExImage != null)
            {
                ExImage.OnLongPress(); 
            }
        }
    }
}