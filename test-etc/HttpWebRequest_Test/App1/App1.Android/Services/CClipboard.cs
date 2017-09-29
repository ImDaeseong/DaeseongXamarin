using Android.Content;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CClipboard))]
namespace App1.Droid.Services
{
    public class CClipboard : IClipboard
    {
        public string GetText()
        {
            return GetTextInternal();
        }

        public Task<string> GetTextAsync()
        {
            return Task.FromResult(GetTextInternal());
        }

        private string GetTextInternal()
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            var item = clipboardManager.PrimaryClip.GetItemAt(0);
            var text = item.Text;
            return text;
        }

        public void SetText(string data)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("", data);
            clipboardManager.PrimaryClip = clip;
        }

    }
}