using BigTed;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CProgressLoading))]
namespace App1.iOS.Services
{
    public class CProgressLoading : IProgressLoading
    {
        public CProgressLoading()
        {
        }

        public void Hide()
        {
            BTProgressHUD.Dismiss();
        }

        public void Show(string title = "Loading")
        {
            BTProgressHUD.Show(title, maskType: ProgressHUD.MaskType.Black);
        }
    }

}