using Android.Content;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CDisplaySize))]
namespace App1.Droid.Services
{
    public class CDisplaySize : IDisplaySize
    {
        static IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

        public CDisplaySize()
        {
        }

        public double getHieght()
        {
            Display d = windowManager.DefaultDisplay;
            Android.Util.DisplayMetrics m = new Android.Util.DisplayMetrics();
            d.GetMetrics(m);

            return (int)((m.HeightPixels) / m.Density);
        }

        public double getWidth()
        {
            Display d = windowManager.DefaultDisplay;
            Android.Util.DisplayMetrics m = new Android.Util.DisplayMetrics();
            d.GetMetrics(m);

            return (int)((m.WidthPixels) / m.Density);
        }
    }

}