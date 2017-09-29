using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Services;

namespace App1
{
    public partial class App : Application
    {
        static IClipboard clip
        {
            get
            {
                return DependencyService.Get<IClipboard>();
            }
        }
        
        public static void ClipboardSetText(string sPlain)
        {
            clip.SetText(sPlain);            
        }

        public static string ClipboardGetText()
        {
            try
            {
                string sText = clip.GetTextAsync().Result;
                return sText;
            }
            catch
            {
                return "";
            }
        }

        public App()
        {
            InitializeComponent();
            

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {            
        }

        protected override void OnSleep()
        {            
        }

        protected override void OnResume()
        {            
        }
    }
}
