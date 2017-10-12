using System;
using Android.Hardware;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App2.Droid;

[assembly: ExportRenderer(typeof(App2.CameraPreview), typeof(CameraPreviewRenderer))]
namespace App2.Droid
{
    public class CameraPreviewRenderer : ViewRenderer<App2.CameraPreview, App2.Droid.CameraPreview>
    {
        CameraPreview cameraPreview;

        protected override void OnElementChanged(ElementChangedEventArgs<App2.CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                cameraPreview = new CameraPreview(Context);
                SetNativeControl(cameraPreview);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
                cameraPreview.Click -= OnCameraPreviewClicked;
            }
            if (e.NewElement != null)
            {
                Control.Preview = Camera.Open((int)e.NewElement.Camera);

                // Subscribe
                cameraPreview.Click += OnCameraPreviewClicked;
            }
        }

        void OnCameraPreviewClicked(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
                cameraPreview.Preview.StopPreview();
                cameraPreview.IsPreviewing = false;
            }
            else
            {
                cameraPreview.Preview.StartPreview();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Preview.Release();
            }
            base.Dispose(disposing);
        }
    }

}