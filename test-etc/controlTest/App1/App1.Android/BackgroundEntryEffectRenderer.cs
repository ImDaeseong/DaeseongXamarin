using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Graphics;
using App1.Droid;

[assembly: ResolutionGroupName("RoutingEffectApp1")]
[assembly: ExportEffect(typeof(BackgroundEntryEffectRenderer), "BackgroundEffect")]
namespace App1.Droid
{   
    public class BackgroundEntryEffectRenderer : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}