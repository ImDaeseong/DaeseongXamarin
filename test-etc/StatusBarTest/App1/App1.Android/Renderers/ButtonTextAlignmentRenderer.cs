using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Views;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(ButtonTextAlignment), typeof(ButtonTextAlignmentRenderer))]
namespace App1.Droid.Renderers
{
    public class ButtonTextAlignmentRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {

            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Gravity = GravityFlags.Center;
                Control.SetPadding(0, 15, 0, 0);
                Control.SetBackgroundResource(Resource.Drawable.EditText);
            }
        }
    }
}