using Xamarin.Forms;

namespace App1
{
    public class MyButton : ContentView
    {
        public MyEditor entry { get; set; }//public Editor entry { get; set; }

        public MyButton()
        {
            entry = new MyEditor();// entry = new Editor();
            entry.Placeholder = "단어를 입력하세요.";
            entry.PlaceholderColor = Color.White;

            var frame = new Frame
            {
                HasShadow = false,
                OutlineColor = Color.FromHex("#e8e8e8"),
                HeightRequest = 50,
                Content = entry,
                BackgroundColor = Color.Transparent
            };

            this.Content = frame;
        }

    }
}
