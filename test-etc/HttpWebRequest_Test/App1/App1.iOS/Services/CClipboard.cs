using UIKit;
using Foundation;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CClipboard))]
namespace App1.iOS.Services
{
    public class CClipboard : IClipboard
    {
        public Task<string> GetTextAsync()
        {
            return Task.FromResult(GetTextInternal());
        }

        public string GetText()
        {
            return GetTextInternal();
        }

        private string GetTextInternal()
        {
            var clipboard = UIPasteboard.General.GetValue("public.utf8-plain-text");
            return clipboard.ToString();
        }

        public void SetText(string data)
        {
            UIPasteboard.General.SetValue(new NSString(data), MobileCoreServices.UTType.Text);            
        }

    }
}