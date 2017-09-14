using AndroidHUD;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CProgressLoading))]
namespace App1.Droid.Services
{
    public class CProgressLoading : IProgressLoading
    {
        public CProgressLoading()
        {
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Dismiss();
            });
        }

        public void Show(string title = "Loading")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
            AndHUD.Shared.Show(Forms.Context, status: title, maskType: MaskType.Black);
            });
        }
    }
}