using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using App1.iOS.Renderers;
using App1.Renderers;

[assembly: ExportRenderer(typeof(ExImage), typeof(ExImageRenderer))]
namespace App1.iOS.Renderers
{
    internal class ExImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            var exImage = Element as ExImage; 
            var gr = new UILongPressGestureRecognizer(o => exImage.OnLongPress());
            
            AddGestureRecognizer(gr);
        }
    }
}