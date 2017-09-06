using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new App1.Page1();
            //MainPage = new App1.Page2();
            //MainPage = new App1.Page3();
            //MainPage = new App1.Page4();
            //MainPage = new App1.Page5();
            //MainPage = new App1.Page6();
            //MainPage = new App1.Page7();
            //MainPage = new App1.Page8();
            //MainPage = new App1.Page9();
            //MainPage = new App1.Page10();
            MainPage = new App1.Page11();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
