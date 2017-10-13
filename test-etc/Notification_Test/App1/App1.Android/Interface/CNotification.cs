using Android.App;
using Android.Content;
using Xamarin.Forms;
using Android.Support.V4.App;
using App1.Droid.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CNotification))]
namespace App1.Droid.Interface
{
    public class CNotification : INotification
    {
        int NotificationId = 1000;

        public void Start()
        {
        }
               
        public void Show(string sTitle, string sMessage)
        {
            var builder = new NotificationCompat.Builder(Forms.Context)
                .SetAutoCancel(true)
                .SetContentTitle(sTitle)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentText(sMessage);

            var notificationManager = (NotificationManager)Forms.Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(NotificationId, builder.Build());
        }

        public void NotificationOffAll()
        {
            Context context = Forms.Context;
            NotificationManager manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            manager.CancelAll();
        }

        public void NotificationVersionOff()
        {
        }
    }
            
}