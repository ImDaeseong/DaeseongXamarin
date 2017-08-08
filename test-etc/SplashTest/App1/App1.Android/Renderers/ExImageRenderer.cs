using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Droid.Renderers;
using App1.Renderers;

[assembly: ExportRenderer(typeof(ExImage), typeof(ExImageRenderer))]
namespace App1.Droid.Renderers
{
    internal class ExImageRenderer : ImageRenderer
    {
        private readonly MyGestureListener _listener;
        private readonly GestureDetector _detector;

        public ExImageRenderer()
        {            
            _listener = new MyGestureListener();            
            _detector = new GestureDetector(_listener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            _listener.ExImage = Element as ExImage;
            GenericMotion += (s, a) => _detector.OnTouchEvent(a.Event);
            Touch += (s, a) => _detector.OnTouchEvent(a.Event);
        }
    }
}