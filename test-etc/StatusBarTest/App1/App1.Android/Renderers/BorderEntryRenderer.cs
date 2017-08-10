using Android.Graphics.Drawables;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using App1.Renderers;
using App1.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(BorderEntry), typeof(BorderEntryRenderer))]
namespace App1.Droid.Renderers
{
    class BorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.SetBackgroundColor(global::Android.Graphics.Color.SkyBlue);
                //Control.SetBackgroundColor(Android.Graphics.Color.SkyBlue);
                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.FromHex("000000").ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;
                //if (ForgotPasswordPage.flag == 1)
                //    Control.Gravity = Android.Views.GravityFlags.Center;
            }
        }
    }
}