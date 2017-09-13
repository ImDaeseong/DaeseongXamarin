using System.Linq;
using UIKit;
using Xamarin.Forms;
using App2.iOS.ShowPopup;
using App2.ShowPopup;

[assembly: Dependency(typeof(ShowOverlay))]
namespace App2.iOS.ShowPopup
{
    public class ShowOverlay : IShowOverLay
    {
        private const int LoadingOverLay = 1001;

        public ShowOverlay()
        {
        }
        
        private static UIWindow MainWindow => UIApplication.SharedApplication.KeyWindow;

        public void HideAll()
        {
            WriteMessage("HideAll");
            HideAll(-1);
        }

        private static void WriteMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        private static bool HideAll(int keepOverlay)
        {
            var found = false;
            var items = MainWindow.Subviews;

            if (keepOverlay != LoadingOverLay)
            {
                var frag = items.FirstOrDefault(x => x.Tag == LoadingOverLay);
                if (frag != null)
                {
                    WriteMessage("Hiding: LoadingOverLay");
                    var overlayView = frag as OverlayView;
                    overlayView?.Hide();
                    found = true;
                }
            }

            return found;
        }

        public void ShowLoadingScreen(XOverLayControl details)
        {
            if (IsActive(LoadingOverLay) == false)
            {
                WriteMessage("ShowLoadingScreen");
                var view = new LoadingView(details)
                {
                    Tag = LoadingOverLay,
                    Alpha = details.Alpha
                };
                MainWindow.AddSubview(view);
                HideAll(LoadingOverLay);
            }
        }

        private static bool IsActive(int overlay)
        {
            var t = UIApplication.SharedApplication.KeyWindow;
            return MainWindow.Subviews.FirstOrDefault(x => x.Tag == overlay) != null;
        }

        public bool CanRun => MainWindow != null;
    }

}