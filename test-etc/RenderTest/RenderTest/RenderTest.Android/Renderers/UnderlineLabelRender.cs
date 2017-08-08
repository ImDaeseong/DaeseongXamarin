﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using RenderTest.Renderers;
using RenderTest.Droid.Renderers;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRender))]
namespace RenderTest.Droid.Renderers
{
    public class UnderlineLabelRender : LabelRenderer
    {
        public UnderlineLabelRender()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            var view = Element as UnderlineLabel;
            if (view.IsUnderline)
            {
                this.Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }
    }
}