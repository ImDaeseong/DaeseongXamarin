using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.PM;
using static Android.App.ActivityManager;
using Xamarin.Forms;
using App1.Interface;
using App1.Droid.Interface;
using Android.Icu.Text;

[assembly: Dependency(typeof(CProcessApk))]
namespace App1.Droid.Interface
{
    public class CProcessApk : IProcessApk
    {
        //현재 동작중인 서비스 목록
        public List<string> GetRunningServicesName()
        {
            List<string> ServiceInfo = new List<string>();
             
            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            List<ActivityManager.RunningServiceInfo> runningService = activityManager.GetRunningServices(int.MaxValue).ToList();
            foreach (ActivityManager.RunningServiceInfo srvInfo in runningService)
            {
                ServiceInfo.Add(srvInfo.Service.PackageName);
                //System.Diagnostics.Debug.WriteLine(srvInfo.Service.PackageName);
            }

            return ServiceInfo;
        }

        public List<string> GetRunningTopPackageName()
        {
            List<string> TopPackageInfo = new List<string>();

            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            List<ActivityManager.RunningTaskInfo> runningService = activityManager.GetRunningTasks(int.MaxValue).ToList();
            foreach (ActivityManager.RunningTaskInfo ActivityInfo in runningService)
            {
                TopPackageInfo.Add(ActivityInfo.TopActivity.PackageName);
                //System.Diagnostics.Debug.WriteLine(ActivityInfo.TopActivity.PackageName);
            }

            return TopPackageInfo;
        }

        public List<string> GetRunningAppProcessPackageName()
        {
            List<string> AppProcessPackageInfo = new List<string>();

            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            IList<ActivityManager.RunningAppProcessInfo> runningAppProcess = activityManager.RunningAppProcesses;
            foreach (ActivityManager.RunningAppProcessInfo runningApp in runningAppProcess)
            {
                AppProcessPackageInfo.Add(runningApp.ProcessName);
                //System.Diagnostics.Debug.WriteLine(runningApp.ProcessName);
            }

            return AppProcessPackageInfo;
        }


        public List<string> GetPackageNames()
        {
            //return GetRunningAppProcessPackageName();// GetRunningTopPackageName();// GetRunningServicesName();
            
            return (from package in Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchUninstalledPackages | PackageInfoFlags.DisabledComponents)
                    select package.PackageName).ToList();
            
            //return (from package in Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll)
            //        select package.PackageName).ToList();

            //return (from package in Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.Activities)
            //        select package.PackageName).ToList();

            //return (from package in Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData)
            //        select package.PackageName).ToList();

            //return (from package in Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData)
            //        where Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(package.PackageName) != null
            //        select package.PackageName).ToList();
        }

        public string GetPackageInfo(string sPackageName)
        {
           
            PackageInfo pkgInfo = Android.App.Application.Context.PackageManager.GetPackageInfo(sPackageName, 0);
            if (pkgInfo == null) return "";

            //SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            //string sInstallTime = dateFormat.Format(new Java.Util.Date(pkgInfo.FirstInstallTime));
            //string sUpdateTime = dateFormat.Format(new Java.Util.Date(pkgInfo.LastUpdateTime));
            
            var First = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(pkgInfo.FirstInstallTime);
            var Last = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(pkgInfo.LastUpdateTime);
            string sInstallTime = First.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            string sUpdateTime = Last.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

            string sVersion = string.Format("{0} {1}", pkgInfo.VersionName, pkgInfo.VersionCode);
            //int nVersionCode = pkgInfo.VersionCode;
            //string sVersionName = pkgInfo.VersionName;
            //string sPackageName = pkgInfo.PackageName;
            
            //string sInstallLocation = pkgInfo.InstallLocation.ToString();
            string sPermission = pkgInfo.ApplicationInfo.Permission;
            //string sProcessName = pkgInfo.ApplicationInfo.ProcessName;
            string sPublicSourceDir = pkgInfo.ApplicationInfo.PublicSourceDir;
            //string sSourceDir = pkgInfo.ApplicationInfo.SourceDir;
            //int nUid = pkgInfo.ApplicationInfo.Uid;
            //string sUiOptions = pkgInfo.ApplicationInfo.UiOptions.ToString();            
            string sFilesize = GetFileSize(sPublicSourceDir);

            string sMsg = sInstallTime + " :: " + sUpdateTime + " :: " + sVersion + " :: " + sPermission + " :: " + sFilesize;
            
            return sMsg;
        }

        public bool IsAppRunning(string sPackageName)
        {
            var actManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService);
            return actManager.RunningAppProcesses.Any(p => p.ProcessName.Equals(sPackageName));

            /*
            var actManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService);
            IList<Android.App.ActivityManager.RunningAppProcessInfo> appProcesses = actManager.RunningAppProcesses;

            foreach (var appProcess in appProcesses)
            {
                if (appProcess.ProcessName == sPackageName)
                    return true;
            }
            return false;
            */
        }

        public bool IsPackageInstalled(string sPackageName)
        {
            var intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(sPackageName);
            if (intent == null)
            {
                return false;
            }
            IList<ResolveInfo> list = Android.App.Application.Context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return list.Count > 0;
        }

        public bool KillApp(string sPackageName)
        {
            try
            {
                var actManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService);
                actManager.KillBackgroundProcesses(sPackageName);
                
                //ActivityManager activityManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService) as ActivityManager;
                //activityManager.KillBackgroundProcesses(item.PackageName);
                //Android.OS.Process.SendSignal(Android.OS.Process.MyPid(), Signal.Kill);

                return true;
            }
            catch { }
            return false;
        }

        public bool Install(string sApkFilename)
        {
            var appPath = sApkFilename;// Path.Combine(Android.OS.Environment.ExternalStorageDirectory + "/download/", sApkFilename);

            try
            {
                var setupIntent = new Intent(Intent.ActionView);
                setupIntent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(appPath)), "application/vnd.android.package-archive");
                Android.App.Application.Context.StartActivity(setupIntent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UnInstall(string sApkFilename)
        {
            try
            {
                var UnIntent = new Intent(Intent.ActionDelete);
                UnIntent.SetData(Android.Net.Uri.Parse("package:" + sApkFilename));
                Android.App.Application.Context.StartActivity(UnIntent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public bool StartApp(string sPackageName)
        {
            try
            {
                var intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(sPackageName);
                Android.App.Application.Context.StartActivity(intent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public string GetPackageLabel(string sPackageName)
        {
            try
            {
                ApplicationInfo info = Android.App.Application.Context.PackageManager.GetApplicationInfo(sPackageName, PackageInfoFlags.MetaData);
                string sLabel = info.LoadLabel(Android.App.Application.Context.PackageManager);
                return sLabel;
            }
            catch { }
            return "";

            /*
            IEnumerable<ApplicationInfo> packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);

            foreach (ApplicationInfo packageInfo in packages)
            {
                if (packageInfo.PackageName == sPackageName)
                {
                    string sLabel = Android.App.Application.Context.PackageManager.GetApplicationLabel(packageInfo);
                    return sLabel;
                }
            }
            return "";
            */
        }

        public ImageSource GetPackageIcon(string sPackageName)
        {
            try
            {
                ApplicationInfo info = Android.App.Application.Context.PackageManager.GetApplicationInfo(sPackageName, PackageInfoFlags.MetaData);
                var PackageIcon = info.LoadIcon(Android.App.Application.Context.PackageManager);
                return GetImageSource(PackageIcon);
            } catch { }
            return null;

            /*
            IEnumerable<ApplicationInfo> packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);
            foreach (ApplicationInfo packageInfo in packages)
            {
               if(packageInfo.PackageName == sPackageName)
                {
                    var PackageIcon = Android.App.Application.Context.PackageManager.GetApplicationIcon(packageInfo);
                    return GetImageSource(PackageIcon);
                }                
            }
            return null;
            */
        }


        public ImageSource GetImageSource(Drawable drawable)
        {
            try
            {
                Bitmap bitmap = ((BitmapDrawable)drawable).Bitmap;
                byte[] bitmapData = GetByteArrayFromBitmap(bitmap);
                ImageSource photo = ImageSource.FromStream(() => new MemoryStream(bitmapData));
                return photo;
            }
            catch
            {
            }
            return null;
        }

        private byte[] GetByteArrayFromBitmap(Bitmap bitmap)
        {
            byte[] bitmapData;
            using (var st = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, st);
                bitmapData = st.ToArray();
            }
            return bitmapData;
        }

        public float GetMemory()
        {
            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            Android.App.ActivityManager.MemoryInfo memoryInfo = new Android.App.ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);
            return memoryInfo.TotalMem / (1024 * 1024);

            /*
            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;
            Android.App.ActivityManager.MemoryInfo memoryInfo = new Android.App.ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);
            double totalUsed = memoryInfo.AvailMem / (1024 * 1024);
            double totalRam = memoryInfo.TotalMem / (1024 * 1024);
            */
        }

        private string GetFileSize(string sPath)
        {
            try
            {
                string sFilesize = "";
                var fs = new FileInfo(sPath);
                var lFileSize = fs.Length / 1024;
                if (lFileSize < 1024)
                    sFilesize = lFileSize + "Kb";
                else
                {
                    var FilesizeMB = Convert.ToDouble(lFileSize / 1024);
                    sFilesize = FilesizeMB.ToString("##.##") + "Mb";
                }
                return sFilesize;
            }
            catch { }
            return "";
        }

        public void GetProcess()
        {
            


            /*
            IList<ApplicationInfo> installedApps = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);
                        
            for (int i = 0; i < installedApps.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(installedApps[i].PackageName);
            }
            */

            /*
            ActivityManager am = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService) as ActivityManager;
            IList<ActivityManager.RunningAppProcessInfo> runningProcess = am.RunningAppProcesses;
            if (runningProcess.Count > 0)
            {
                foreach (ActivityManager.RunningAppProcessInfo processInfo in runningProcess)
                {
                    if (processInfo.Importance == Android.App.Importance.Foreground)
                    {
                        foreach (string activeProcess in processInfo.PkgList)
                        {
                            System.Diagnostics.Debug.WriteLine(activeProcess);
                        }
                    }
                }
            }
            */

            /*
            var Packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.Activities);
            //var Packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            foreach (var item in Packages)
            {
                string installlocation = item.SourceDir.ToString();
                var PackageImage = Android.App.Application.Context.PackageManager.GetApplicationIcon(item);
                string label = Android.App.Application.Context.PackageManager.GetApplicationLabel(item);

                //var appInfo = Android.App.Application.Context.PackageManager.GetApplicationInfo(item.ProcessName, 0);
                //var appLabel = Android.App.Application.Context.PackageManager.GetApplicationLabel(appInfo);
                //var versionNumber = Android.App.Application.Context.PackageManager.GetPackageInfo(item.ProcessName, 0).VersionName;

                int Total = Packages.Count;
                System.Diagnostics.Debug.WriteLine(item.PackageName + ":" + item.ProcessName);
            }
            */

            /*
            IEnumerable<ApplicationInfo> packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);

            foreach (ApplicationInfo packageInfo in packages)
            {
                System.Diagnostics.Debug.WriteLine(packageInfo.PackageName);
            }
            */

            /*
            var actManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService);
            foreach (var service in actManager.GetRunningServices(int.MaxValue))
            {
                if ( service.Foreground )
                {
                    System.Diagnostics.Debug.WriteLine("Foreground:" + service.Service.ClassName);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Background:" + service.Service.ClassName);
                }               
            }
            */

            /*
            ActivityManager activityManager = (ActivityManager)Forms.Context.GetSystemService(Context.ActivityService) as ActivityManager;
            IList<Android.App.ActivityManager.RunningAppProcessInfo> appProcesses = activityManager.RunningAppProcesses;
            foreach (var appProcess in appProcesses)
            {
                System.Diagnostics.Debug.WriteLine(appProcess.ProcessName);
            }
            */

            /*
            var Packages = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            foreach (var item in Packages)
            {
                int Total = Packages.Count;
                string installlocation = item.SourceDir.ToString();

                var PackageImage = Android.App.Application.Context.PackageManager.GetApplicationIcon(item);

                string label = Android.App.Application.Context.PackageManager.GetApplicationLabel(item);

                System.Diagnostics.Debug.WriteLine(item.PackageName + ":" + item.ProcessName);
            }
            */

            /*
            private List<ApplicationInfo> LocalApplications;
            private void Test()
            {
                List<string> list = new List<string>();

                var apps = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);

                for (int i = 0; i < apps.Count; i++)
                {
                    var app = apps[i].LoadLabel(Android.App.Application.Context.PackageManager);
                    //System.Diagnostics.Debug.WriteLine(app);
                    list.Add(app);
                }
            }
            */

        }

    }
}