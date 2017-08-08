using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using App1.iOS;

[assembly: ResolutionGroupName("RoutingEffectApp1")]
[assembly: ExportEffect(typeof(BackgroundEntryEffectRenderer), "BackgroundEffect")]
namespace App1.iOS
{    
    public class BackgroundEntryEffectRenderer : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var view = this.Control as UITextField;
                if (view == null)
                    return;

                view.BorderStyle = UITextBorderStyle.Line;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}