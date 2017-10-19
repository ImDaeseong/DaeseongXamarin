using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.Interface
{
    public interface IProcessApk
    {
        List<string> GetPackageNames();

        string GetPackageInfo(string sPackageName);

        bool IsAppRunning(string sPackageName);

        bool IsPackageInstalled(string sPackageName);

        bool KillApp(string sPackageName);

        bool Install(string sApkFilename);

        bool UnInstall(string sApkFilename);

        bool StartApp(string sPackageName);

        string GetPackageLabel(string sPackageName);

        ImageSource GetPackageIcon(string sPackageName);

        float GetMemory();

        void GetProcess();

    }
}
