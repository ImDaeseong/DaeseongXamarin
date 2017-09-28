using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() { Title = "Item 1", Icon = "bookA.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Item 2", Icon = "bookB.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Item 3", Icon = "bookC.png", TargetType = typeof(Page3) };
            var page4 = new MasterPageItem() { Title = "Item 4", Icon = "bookD.png", TargetType = typeof(Page4) };
            var page5 = new MasterPageItem() { Title = "Item 5", Icon = "bookE.png", TargetType = typeof(Page5) };
            var page6 = new MasterPageItem() { Title = "Item 6", Icon = "bookF.png", TargetType = typeof(Page6) };
            var page7 = new MasterPageItem() { Title = "Item 7", Icon = "bookG.png", TargetType = typeof(Page7) };

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);
                        
            navigationList.ItemsSource = menuList;


            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page1)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }

}
