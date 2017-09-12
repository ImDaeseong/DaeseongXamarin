using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CScanner))]
namespace App1.Droid.Services
{
    public class CScanner : IScanner
    {
        public async Task<string> ScanAsync()
        {                        
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();
            if (result != null)
            {
                return result.Text;
            }
            return string.Empty;
        }

        /*
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions()
            {
                //UseFrontCameraIfAvailable = true,
                //Check diferents formats in http://barcode.tec-it.com/en
                // PossibleFormats = new List<ZXing.BarcodeFormat> {  ZXing.BarcodeFormat.CODE_128 }
            };
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "TopText",
                BottomText = "BottomText"
            };

            var result = await scanner.Scan(optionsCustom);
            if (result != null)
            {
                return result.Text;
            }
            return string.Empty;
        }
        */
    }

}