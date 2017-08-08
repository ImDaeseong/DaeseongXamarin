using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1;
using App1.Droid;

[assembly: ExportRenderer(typeof(LetterSpacingLabel), typeof(LetterSpacingLabelRenderer))]
namespace App1.Droid
{
    public class LetterSpacingLabelRenderer : LabelRenderer
    {
        protected LetterSpacingLabel LetterSpacingLabel { get; private set; }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                this.LetterSpacingLabel = (LetterSpacingLabel)this.Element;
            }

            var letterSpacing = this.LetterSpacingLabel.LetterSpacing;
            this.Control.LetterSpacing = letterSpacing;

            this.UpdateLayout();
        }        
    }
}