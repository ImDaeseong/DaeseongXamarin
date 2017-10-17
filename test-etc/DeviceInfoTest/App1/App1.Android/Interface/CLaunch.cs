using System;
using System.Linq;
using Android.Content;
using Android.Content.PM;
using Xamarin.Forms;
using App1.Interface;
using App1.Droid.Interface;

[assembly: Dependency(typeof(CLaunch))]
namespace App1.Droid.Interface
{
    public class CLaunch : ILaunch
    {
        private Context Context
        {
            get { return Android.App.Application.Context; }
        }

        public CLaunch()
        {
        }

        public bool IsInstalled(string sPackageName)
        {
            var installedApps = Context.PackageManager.GetInstalledPackages(PackageInfoFlags.MetaData);
            return installedApps.Any(x => x.PackageName.Equals(sPackageName, StringComparison.InvariantCultureIgnoreCase));
        }

        public void LaunchApp(string sPackageName)
        {
            var installedApps = Context.PackageManager.GetInstalledPackages(PackageInfoFlags.MetaData);
            var intent = Context.PackageManager.GetLaunchIntentForPackage(sPackageName);
            Context.StartActivity(intent);
        }
    }

}