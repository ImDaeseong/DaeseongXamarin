using System;
using Android.Content;
using Android.Content.Res;
using System.ComponentModel;
using FAB = Android.Support.Design.Widget.FloatingActionButton;
using Xamarin.Forms.Platform.Android;
using App1.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(App1.Renderers.FloatingActionButton), typeof(FloatingActionButtonRender))]
namespace App1.Droid.Renderers
{
    public class FloatingActionButtonRender : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<App1.Renderers.FloatingActionButton, FAB>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<App1.Renderers.FloatingActionButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            var fab = new FAB(Context);
            // set the bg
            fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());

            // set the icon
            var elementImage = Element.Image;
            var imageFile = elementImage?.File;

            if (imageFile != null)
            {
                fab.SetImageDrawable(Context.Resources.GetDrawable(imageFile));
            }
            fab.Click += Fab_Click;
            SetNativeControl(fab);

        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            Control.BringToFront();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var fab = (FAB)Control;
            if (e.PropertyName == nameof(Element.ButtonColor))
            {
                fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());
            }
            if (e.PropertyName == nameof(Element.Image))
            {
                var elementImage = Element.Image;
                var imageFile = elementImage?.File;

                if (imageFile != null)
                {
                    fab.SetImageDrawable(Context.Resources.GetDrawable(imageFile));
                }
            }
            base.OnElementPropertyChanged(sender, e);

        }

        private void Fab_Click(object sender, EventArgs e)
        {
            // proxy the click to the element
            ((IButtonController)Element).SendClicked();
        }
    }
}