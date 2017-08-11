using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private List<ImgAllFile> imgAllList;

        public Page1()
        {
            InitializeComponent();

            imgAllList = null;
            imgAllList = new List<ImgAllFile>();

            carView.ItemsSource = imgAllList;

            for(int i=0; i<20; i++)
            {
                imgAllList.Add(new ImgAllFile(string.Format("Text {0}", i+1)));
            }
        }
    }
    
    class ImgAllFile
    {
        public string DisplayName { get; set; }

        public ImgAllFile(string DisplayName)
        {
            this.DisplayName = DisplayName;
        }
    }

}