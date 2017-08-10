using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using App1.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EditText), typeof(EditTextRenderer))]
namespace App1.Droid.Renderers
{
    public class EditTextRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.EditText);
                //Control.TextAlignment = Android.Views.TextAlignment.Center;
                Control.Gravity = GravityFlags.Center;
                //Control.HintTextColors = Color.Gray.ToAndroid ();

            }
        }
    }
}