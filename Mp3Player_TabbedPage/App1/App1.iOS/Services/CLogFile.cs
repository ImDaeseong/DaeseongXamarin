using System.IO;
using App1.iOS;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(CLogFile))]
namespace App1.iOS
{
    public class CLogFile : ILogFile
    {
        public async Task WriteString(string sText)
        {
            string spath = "";
            using (var writer = File.CreateText(spath))
            {
                await writer.WriteAsync(sText);
            }
        }     

    }
}