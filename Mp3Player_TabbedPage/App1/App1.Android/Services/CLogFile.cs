using Xamarin.Forms;
using App1.Droid;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

[assembly: Dependency(typeof(CLogFile))]
namespace App1.Droid
{
    public class CLogFile : ILogFile  
    {
        public async Task WriteString(string sText)
        { 
            string spath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Music/DaeseongLog.txt";
            using (var writer = File.CreateText(spath))
            {
                await writer.WriteAsync(sText);
            }
        }
        
    }

}