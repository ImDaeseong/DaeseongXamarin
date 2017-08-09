using Android.Telephony;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;


[assembly: Dependency(typeof(CSmsService))]
namespace App1.Droid.Services
{
    public class CSmsService : ISmsService
    {
        public void SendSMS(string sPhoneNumber, string sSms)
        {
            SmsManager.Default.SendTextMessage(sPhoneNumber, null, sSms, null, null);
        }
    }
}