using System;
using Xamarin.Forms;
using shSpeak.Renderers;
using shSpeak.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace shSpeak.iOS.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            Layer.CornerRadius = (nfloat)10.0;
        }
    }
}