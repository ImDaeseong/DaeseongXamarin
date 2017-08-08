using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = Movie.All;
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();

            await App.MovieManager.GetTasksAsync();
        }

        private async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Movie item = (Movie)e.Item;

            await Navigation.PushAsync(new ViewPage(item));
            ((ListView)sender).SelectedItem = null;
        }

    }
}
