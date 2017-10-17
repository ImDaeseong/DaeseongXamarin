using System;

namespace App1.Interface
{
    public interface ILaunch
    {
        void LaunchApp(string sPackageName);

        bool IsInstalled(string sPackageName);
    }
}
