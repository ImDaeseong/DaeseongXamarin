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
    public partial class TextView3 : ContentView
    {
        List<TextInfoClass> textList;
        int position = 0;


        public TextView3()
        {
            InitializeComponent();

            textList = new List<TextInfoClass>
            {
                new TextInfoClass { TextLine = "TextLine1", TextColor = Color.Red },
                new TextInfoClass { TextLine = "TextLine2", TextColor = Color.Green },
                new TextInfoClass { TextLine = "TextLine3", TextColor = Color.Blue }
            };

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                lblText.Text = textList[position].TextLine;
                lblText.TextColor = textList[position].TextColor;
                position++;
                if (position == textList.Count)
                    position = 0;
                return true;
            });
        }
    }

    public class TextInfoClass
    {
        public string TextLine { get; set; }
        public Color TextColor { get; set; }
    }


}