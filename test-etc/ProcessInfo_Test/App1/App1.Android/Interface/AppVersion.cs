using System;
using Android.OS;
using Android.Provider;
using Xamarin.Forms;
using App1.Interface;
using App1.Droid.Interface;
using Android.Bluetooth;

[assembly: Dependency(typeof(AppVersion))]
namespace App1.Droid.Interface
{
    public class AppVersion : IAppVersion
    {
        public string VersionString
        {
            get
            {
                var manager = Forms.Context.PackageManager;
                var info = manager.GetPackageInfo(Forms.Context.PackageName, 0);
                return info.VersionName;
            }
        }

        public string DeviceName
        {
            get
            {
                return Build.Device;
            }
        }

        public string DeviceId
        {
            get
            {
                return Settings.Secure.GetString(Forms.Context.ContentResolver, Settings.Secure.AndroidId);
            }
        }

        public string PackageName
        {
            get
            {
                return Forms.Context.PackageName;
            }
        }

        public string AppVersionName
        {
            get
            {
                return Forms.Context.PackageManager.GetPackageInfo(Forms.Context.PackageName, 0).VersionName;
            }
        }

        public string AppVersionCode
        {
            get
            {
                return Forms.Context.PackageManager.GetPackageInfo(Forms.Context.PackageName, 0).VersionCode.ToString();
            }
        }

        public string FirmwareVersion
        {
            get
            {
                return Build.VERSION.Release;
            }
        }

        public string HardwareVersion
        {
            get
            {
                return Build.Hardware;
            }
        }

        public string Manufacturer
        {
            get
            {
                return Build.Manufacturer;
            }
        }

        public string ModelName
        {
            get
            {
                return Build.Model;
            }
        }
        
        public string GetId
        {
            get
            {
                return Build.Serial;
            }
        }
        
    }
}