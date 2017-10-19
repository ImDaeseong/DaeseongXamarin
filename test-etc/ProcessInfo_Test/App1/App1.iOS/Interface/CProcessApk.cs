using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.iOS.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CProcessApk))]
namespace App1.iOS.Interface
{
    public class CProcessApk : IProcessApk
    {
        public List<string> GetPackageNames()
        {
            return null;
        }

        public string GetPackageInfo(string sPackageName)
        {
            return "";
        }

        public bool IsAppRunning(string sPackageName)
        {            
            return false;
        }

        public bool IsPackageInstalled(string sPackageName)
        {
            return false;
        }

        public bool KillApp(string sPackageName)
        {
            return false;
        }

        public bool Install(string sApkFilename)
        {
            return false;
        }

        public bool UnInstall(string sApkFilename)
        {
            return false;
        }

        public bool StartApp(string sPackageName)
        {
            return false;
        }

        public string GetPackageLabel(string sPackageName)
        {            
            return "";
        }

        public ImageSource GetPackageIcon(string sPackageName)
        {
            return null;
        }

        public float GetMemory()
        {
            return 0;
           //return (Foundation.NSProcessInfo.ProcessInfo.PhysicalMemory / (1024 * 1024)).ToString("f2");
        }

        public void GetProcess()
        {
        }
    }

}