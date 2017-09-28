using Android.Content;
using Android.Net;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(NetworkConnection))]
namespace App1.Droid.Services
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected
        {
            get
            {

                var connectivityManager = (ConnectivityManager)global::Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
                var activeConnection = connectivityManager.ActiveNetworkInfo;
                return ((activeConnection != null) && activeConnection.IsConnected);
            }
        }

        public bool IsWifi
        {
            get
            {
                var connectivityManager = (ConnectivityManager)global::Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
                var activeConnection = connectivityManager.ActiveNetworkInfo;
                var mobileState = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi).GetState();
                return (mobileState == NetworkInfo.State.Connected);
            }
        }
        
        public bool IsMobileCarrier
        {
            get
            {
                var connectivityManager = (ConnectivityManager)global::Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
                var activeConnection = connectivityManager.ActiveNetworkInfo;
                var mobileState = connectivityManager.GetNetworkInfo(ConnectivityType.Mobile).GetState();
                return (mobileState == NetworkInfo.State.Connected);
            }
        }

    }

}