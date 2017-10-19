using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Interface;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessPage : ContentPage
    {

        private List<ProcessPackage> proList;

        private IProcessApk ProcessApk;
        private IToast Toast;

        public ProcessPage()
        {
            InitializeComponent();

            ProcessApk = DependencyService.Get<IProcessApk>();
            Toast = DependencyService.Get<IToast>();


            proList = new List<ProcessPackage>();
            ProcessListview.ItemsSource = proList;
            ProcessListview.ItemSelected += ProcessListview_ItemSelected;
            ProcessListview.ItemTapped += ProcessListview_ItemTapped;


            List<string> lstPackage = ProcessApk.GetPackageNames();
            for (int i = 0; i < lstPackage.Count; i++)
            {
                ImageSource icon = ProcessApk.GetPackageIcon(lstPackage[i].ToString());
                string sPackageLabel = ProcessApk.GetPackageLabel(lstPackage[i].ToString());
                string PackageName = lstPackage[i].ToString();

                proList.Add(new ProcessPackage(icon, sPackageLabel, PackageName));
            }

            System.Diagnostics.Debug.WriteLine("총개수:" + lstPackage.Count);

        }

        private void ProcessListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = (ProcessPackage)e.Item;
                //ProcessApk.StartApp(item.PackageName);
                //ProcessApk.UnInstall(item.PackageName);
                                
                string sMsg = ProcessApk.GetPackageInfo(item.PackageName);
                Toast.Show(sMsg);

                int nIndex = proList.IndexOf(item);
            }
            catch { }
        }

        private void ProcessListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            if (e.SelectedItem != null)
            {
                var item = (ProcessPackage)e.SelectedItem;
                int nIndex = proList.IndexOf(item);
                ProcessListview.SelectedItem = null;
            }
            */
        }
    }

    class ProcessPackage
    {
        
        public ImageSource PackageIcon { get; set; }

        public string PackageLabel { get; set; }

        public string PackageName { get; set; }

        public ProcessPackage(ImageSource PackageIcon, string PackageLabel, string PackageName)
        {
            this.PackageIcon = PackageIcon;
            this.PackageLabel = PackageLabel;
            this.PackageName = PackageName;            
        }
    }

}