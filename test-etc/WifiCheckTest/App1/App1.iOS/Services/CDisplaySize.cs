using UIKit;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;


[assembly: Dependency(typeof(CDisplaySize))]
namespace App1.iOS.Services
{
    public class CDisplaySize : IDisplaySize
    {     
        public CDisplaySize()
        {
        }

        public double getHieght()
        {
            return UIScreen.MainScreen.Bounds.Height;
        }

        public double getWidth()
        {
            return UIScreen.MainScreen.Bounds.Width;
        }
    }

}