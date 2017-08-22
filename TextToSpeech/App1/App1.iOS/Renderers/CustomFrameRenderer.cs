using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App1.Renderers;
using App1.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace App1.iOS.Renderers
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