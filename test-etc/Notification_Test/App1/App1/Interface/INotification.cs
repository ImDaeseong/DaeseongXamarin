using System;

namespace App1.Interface
{
    public interface INotification
    {
        void Start();

        void Show(string sTitle, string sMessage);

        void NotificationOffAll();

        void NotificationVersionOff();
    }
    
}
