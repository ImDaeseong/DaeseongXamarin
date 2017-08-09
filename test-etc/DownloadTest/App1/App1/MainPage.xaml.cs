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
       
        List<TextSpinClass> textList;
        int position = 0;


        public MainPage()
        {
            InitializeComponent();

            textList = new List<TextSpinClass>
            {
                new TextSpinClass { LineOfText = "MAN - BSN", ColorOfText = Color.Blue },
                new TextSpinClass { LineOfText = "21:30", ColorOfText = Color.Blue },
                new TextSpinClass { LineOfText = "NOW BOARDING", ColorOfText = Color.Green }
            };
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                rotateText.Text = textList[position].LineOfText;
                rotateText.TextColor = textList[position].ColorOfText;
                position++;
                if (position == textList.Count)
                    position = 0;
                return true;
            });            
        }


    }
}
