using Android.Content.PM;
using App1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace App1
{
    public partial class MainPage : ContentPage
    {        
        private IAppVersion AppInfo;
        private IMememoryInfo Memory;
                
        public MainPage()
        {
            InitializeComponent();
                        
            AppInfo = DependencyService.Get<IAppVersion>();
            Memory = DependencyService.Get<IMememoryInfo>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string sVersion = AppInfo.VersionString;
            string sDeviceName = AppInfo.DeviceName;
            string sDeviceId = AppInfo.DeviceId;
            string sPackageName = AppInfo.PackageName;
            string sAppVersionName = AppInfo.AppVersionName;
            string sAppVersionCode = AppInfo.AppVersionCode;
            string sFirmwareVersion = AppInfo.FirmwareVersion;
            string sHardwareVersion = AppInfo.HardwareVersion;
            string sManufacturer = AppInfo.Manufacturer;
            string sModelName = AppInfo.ModelName;
            string sGetId = AppInfo.GetId;
            
            float fTotalMemory = Memory.GetMemory();

            l1.Text = sVersion;
            l2.Text = sDeviceName;
            l3.Text = sDeviceId;
            l4.Text = sPackageName;
            l5.Text = sAppVersionName;
            l6.Text = sAppVersionCode;
            l7.Text = sFirmwareVersion;
            l8.Text = sHardwareVersion;
            l9.Text = sManufacturer;
            l10.Text = sModelName;
            l11.Text = sGetId;            
            l12.Text = string.Format("{0}", fTotalMemory);
        }
    }
}
