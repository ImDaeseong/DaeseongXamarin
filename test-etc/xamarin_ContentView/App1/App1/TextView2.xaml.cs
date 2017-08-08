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
    public partial class TextView2 : ContentView
    {
        public TextView2()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            ChangeLabel();
            return true;
        }

        private async void ChangeLabel()
        {
            List<Task> tranistion = new List<Task>();
            tranistion.Add(lblDate1.TranslateTo(-360, lblDate1.TranslationY));
            tranistion.Add(lblDate2.TranslateTo(0, lblDate2.TranslationY));
            await Task.WhenAll(tranistion);

            var tempsource = lblDate1.Text;
            lblDate1.Text = lblDate2.Text;
            lblDate2.Text = tempsource;
            lblDate1.TranslationX = 0;
            lblDate2.TranslationX = 360;
        }

    }
}