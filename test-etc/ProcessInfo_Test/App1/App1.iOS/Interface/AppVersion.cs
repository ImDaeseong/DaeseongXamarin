using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using System.Runtime.InteropServices;
using Xamarin.Forms;
using App1.Interface;
using App1.iOS.Interface;

[assembly: Dependency(typeof(AppVersion))]
namespace App1.iOS.Interface
{
    public class AppVersion : IAppVersion
    {
        public string VersionString
        {
            get
            {
                NSString versionString = NSBundle.MainBundle.InfoDictionary.ObjectForKey(new NSString("CFBundleShortVersionString")) as NSString;
                NSString buildString = NSBundle.MainBundle.InfoDictionary.ObjectForKey(new NSString("CFBundleVersion")) as NSString;
                return versionString.ToString() + "." + buildString.ToString();
            }
        }

        public string DeviceName
        {
            get
            {
                return UIDevice.CurrentDevice.Name.ToString();
            }
        }

        public string DeviceId
        {
            get
            {
                return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            }
        }

        public string PackageName
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary["CFBundleDisplayName"].ToString();
            }
        }
        
        public string AppVersionName
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString();
            }
        }
      
        public string AppVersionCode
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();
            }
        }

        public string FirmwareVersion
        {
            get
            {
                return UIDevice.CurrentDevice.SystemVersion;
            }
        }

        public string HardwareVersion
        {
            get
            {
                var hardwareVersion = GetSystemProperty("hw.machine");
                return hardwareVersion;
            }
        }

        public string Manufacturer
        {
            get
            {
                return "Apple";
            }
        }

        public string ModelName
        {
            get
            {
                return UIDevice.CurrentDevice.Model;
            }
        }

        private string GetFriendlyName
        {
            get
            {
                return UIDevice.CurrentDevice.Name.ToString();
            }
        }

        public string GetId
        {
            get
            {
                return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            }
        }



        private static void GetCapacity(out ulong capacity, out ulong available)
        {
            var space = NSFileManager.DefaultManager.GetFileSystemAttributes(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            capacity = space.Size;
            available = space.FreeSize;
        }

        public static string GetSystemProperty(string property)
        {
            var pLen = Marshal.AllocHGlobal(sizeof(int));
            sysctlbyname(property, IntPtr.Zero, pLen, IntPtr.Zero, 0);
            var length = Marshal.ReadInt32(pLen);
            var pStr = Marshal.AllocHGlobal(length);
            sysctlbyname(property, pStr, pLen, IntPtr.Zero, 0);
            return Marshal.PtrToStringAnsi(pStr);
        }

        [DllImport(Constants.SystemLibrary)]
        internal static extern int sysctlbyname(
            [MarshalAs(UnmanagedType.LPStr)] string property,
            IntPtr output,
            IntPtr oldLen,
            IntPtr newp,
            uint newlen);

    }
}