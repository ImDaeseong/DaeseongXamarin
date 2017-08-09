using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(NewButton), typeof(NewButtonRenderer))]
namespace App1.Droid.Renderers
{
    public class NewButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.RoundedButton);
                Control.SetTextColor(global::Android.Graphics.Color.White);
            }
        }
    }
}