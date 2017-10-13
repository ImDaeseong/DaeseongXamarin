﻿using System;
using System.Threading.Tasks;
using App1.Controls;
using App1.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace App1.iOS.Renderers
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, NativeCameraPreview>
    {
        NativeCameraPreview nativeCameraPreview;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                nativeCameraPreview = new NativeCameraPreview(e.NewElement.Camera);
                SetNativeControl(nativeCameraPreview);
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
            }
            if (e.NewElement != null)
            {
                // Subscribe
                e.NewElement.TakePhotoAsync = async () =>
                {
                    var stream = await nativeCameraPreview.CaptureImage();
                    return ImageSource.FromStream(() => stream);
                };

                e.NewElement.SwitchCamera = (cameraOption) =>
                {
                    nativeCameraPreview.CameraOption = cameraOption;
                    return true;
                };
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.CaptureSession.Dispose();
                Control.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}