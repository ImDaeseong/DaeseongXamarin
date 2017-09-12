using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CScanner))]
namespace App1.iOS.Services
{
    public class CScanner : IScanner
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                return result.Text;
            }
            return string.Empty;
        }

    }

}