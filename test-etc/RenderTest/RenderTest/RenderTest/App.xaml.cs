using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RenderTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new RenderTest.Page1();
            //MainPage = new RenderTest.Page2();
            MainPage = new RenderTest.Page3();
            //MainPage = new RenderTest.Page4();
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
