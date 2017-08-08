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
    public partial class RotationView : ContentView
    {          
        private string AnimationKey = "imgAni";

        public RotationView()
        {
            InitializeComponent();            
        }
        
        protected override void OnParentSet()
        {
            base.OnParentSet();
           
            if (Parent != null)
            {
                //한번만
                this.Animate(AnimationKey, v => imgAni.Rotation = v, 0d, 360d,
                    length: 1000,
                    easing: null,
                    repeat: () => false);

                //무한반복
                //this.Animate(AnimationKey, v => imgAni.Rotation = v, 0d, 360d, repeat: () => true);
            }
            else
            {
                this.AbortAnimation(AnimationKey);
            }
        }
    }
}