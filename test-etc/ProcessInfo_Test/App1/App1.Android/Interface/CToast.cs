using Android.Widget;
using Xamarin.Forms;
using App1.Droid.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CToast))]

namespace App1.Droid.Interface
{
    public class CToast : IToast
    {
        public void Show(string sMessage)
        {
            Toast.MakeText(Android.App.Application.Context, sMessage, ToastLength.Short).Show();
        }
    }
}