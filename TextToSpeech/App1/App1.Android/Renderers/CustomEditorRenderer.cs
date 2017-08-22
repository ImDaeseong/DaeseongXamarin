using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace App1.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            if (Control != null)
            {
                Control.Background = Resources.GetDrawable(Resource.Drawable.EditorBorder);
                Control.SetHint(Resource.String.description);
                InputFilterLengthFilter filter = new InputFilterLengthFilter(255);
                Control.SetFilters(new IInputFilter[] { filter });
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
        }
    }
}