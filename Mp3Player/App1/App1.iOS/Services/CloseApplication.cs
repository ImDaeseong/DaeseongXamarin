using App1.iOS;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseApplication))]
namespace App1.iOS
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            Thread.CurrentThread.Abort();
        }
    }
}
