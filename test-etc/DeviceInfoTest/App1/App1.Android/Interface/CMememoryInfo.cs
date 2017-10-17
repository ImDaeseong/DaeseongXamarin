using System;
using Xamarin.Forms;
using App1.Droid.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CMememoryInfo))]
namespace App1.Droid.Interface
{
    public class CMememoryInfo : IMememoryInfo
    {
        public float GetMemory()
        {
            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            Android.App.ActivityManager.MemoryInfo memoryInfo = new Android.App.ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);
            return memoryInfo.TotalMem / (1024 * 1024);
        }
    }
}