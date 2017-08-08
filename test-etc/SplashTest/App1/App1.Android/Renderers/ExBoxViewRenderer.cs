using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;
using System.ComponentModel;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(ExBoxView), typeof(ExBoxViewRenderer))]
namespace App1.Droid.Renderers
{
    internal class ExBoxViewRenderer : BoxRenderer
    {
        public override void Draw(Canvas canvas)
        {         
            var exBoxView = (ExBoxView)Element; 
            
            using (var paint = new Paint())
            {

                var shadowSize = exBoxView.ShadowSize;
                var blur = shadowSize;
                var radius = exBoxView.Radius;

                paint.AntiAlias = true;
                
                paint.Color = (Xamarin.Forms.Color.FromRgba(0, 0, 0, 112)).ToAndroid();
                paint.SetMaskFilter(new BlurMaskFilter(blur, BlurMaskFilter.Blur.Normal));
                var rectangle = new RectF(shadowSize, shadowSize, Width - shadowSize, Height - shadowSize);
                canvas.DrawRoundRect(rectangle, radius, radius, paint);

                paint.Color = exBoxView.Color.ToAndroid();
                paint.SetMaskFilter(null);
                rectangle = new RectF(0, 0, Width - shadowSize * 2, Height - shadowSize * 2);
                canvas.DrawRoundRect(rectangle, radius, radius, paint);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Radius")
            {
                Invalidate(); 
            }
        }
    }
}