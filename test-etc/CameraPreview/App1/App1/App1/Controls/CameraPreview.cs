﻿using System;
using System.Threading.Tasks;
using App1.Enums;
using Xamarin.Forms;

namespace App1.Controls
{
    public class CameraPreview : View
    {
        public static readonly BindableProperty CameraProperty =
            BindableProperty.Create(
                propertyName: "Camera",
                returnType: typeof(CameraOptions),
                declaringType: typeof(CameraPreview),
                defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        public Func<Task<ImageSource>> TakePhotoAsync { set; get; }

        public Func<CameraOptions, bool> SwitchCamera { set; get; }
    }
}
