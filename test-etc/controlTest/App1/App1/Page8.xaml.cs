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
    public partial class Page8 : ContentPage
    {
        public Page8()
        {
            InitializeComponent();

            // -- 이 속성은 검색 버튼들이 어떤 상태인지를 파악 하기 위함 입니다.
            bool isClickHospital = false;
            bool isClickDrugStore = false;


            SearchBtnHospital.Clicked += async (sender, e) =>
            {
                if (!isClickHospital)
                {
                    // -- (비동기)위치변경 애니메이션으로 검색 버튼을 노출합니다.
                    await SearchBtnsTop.TranslateTo(0, 200, 700, Easing.SinIn);
                    isClickHospital = true;
                }
                else
                {
                    // -- (비동기)위치변경 애니메이션으로 검색 버튼을 숨깁니다.
                    await SearchBtnsTop.TranslateTo(0, -1, 700, Easing.SinIn);
                    isClickHospital = false;
                }
            };

            SearchBtnDrugstore.Clicked += async (sender, e) =>
            {
                if (!isClickDrugStore)
                {
                    await SearchBtnBottom.TranslateTo(0, -200, 700, Easing.SinIn);
                    isClickDrugStore = true;
                }
                else
                {
                    await SearchBtnBottom.TranslateTo(0, 1, 700, Easing.SinIn);
                    isClickDrugStore = false;
                }
            };
            
        }
    }
}