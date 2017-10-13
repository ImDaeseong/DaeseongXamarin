using UIKit;
using Foundation;
using Xamarin.Forms;
using App1.iOS.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CNotification))]
namespace App1.iOS.Interface
{
    public class CNotification : INotification
    {        
        public void Start()
        {
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }

        public void Show(string sTitle, string sMessage)
        {
            Device.BeginInvokeOnMainThread(() => {
                var notification = new UILocalNotification
                {
                    FireDate = NSDate.FromTimeIntervalSinceNow(0),
                    AlertTitle = sTitle,
                    AlertBody = sMessage
                };
                UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            });
        }

        public void NotificationOffAll()
        {
            //등록된 알림 모두 취소
            UIApplication.SharedApplication.CancelAllLocalNotifications();
        }

        public void NotificationVersionOff()
        {
            //어플 버전 비표시(0:비표시, 3:표시)
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
    }
}