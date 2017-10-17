using System;
using NUnit.Framework;
using Foundation;
using Xamarin.Forms;
using App1.iOS.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CMememoryInfo))]
namespace App1.iOS.Interface
{
    public class CMememoryInfo : IMememoryInfo
    {
        public float GetMemory()
        {
            return NSProcessInfo.ProcessInfo.PhysicalMemory / (1024 * 1024);
        }
    }
}