using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using System.Drawing;
using System.ComponentModel;
using App1.Renderers;
using App1.iOS.Renderers;

[assembly: ExportRenderer(typeof(ExBoxView), typeof(ExBoxViewRenderer))]
namespace App1.iOS.Renderers
{
    internal class ExBoxViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            var exBoxView = (ExBoxView)Element; 
            using (var context = UIGraphics.GetCurrentContext())
            {
                var shadowSize = exBoxView.ShadowSize;
                var blur = shadowSize;
                var radius = exBoxView.Radius;

                context.SetFillColor(exBoxView.Color.ToCGColor()); 
                var bounds = Bounds.Inset(shadowSize * 2, shadowSize * 2);
                context.AddPath(CGPath.FromRoundedRect(bounds, radius, radius));
                context.SetShadow(new SizeF(shadowSize, shadowSize), blur);
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Radius")
            {
                SetNeedsDisplay(); 
            }
        }
    }
}