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
        private List<TextItem> TextAllList;

        public Page1()
        {
            InitializeComponent();

            TextAllList = null;
            TextAllList = new List<TextItem>();

            carView.ItemsSource = TextAllList;

            for(int i=0; i<20; i++)
            {
                TextAllList.Add(new TextItem(string.Format("Text {0}", i+1)));
            }
        }
    }
    
    class TextItem
    {
        public string DisplayName { get; set; }

        public TextItem(string DisplayName)
        {
            this.DisplayName = DisplayName;
        }
    }

}