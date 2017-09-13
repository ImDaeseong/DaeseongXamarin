using Android.App;
using Android.OS;
using Android.Views;
using App2.ShowPopup;

namespace App2.Droid.ShowPopup
{
    internal class LoadingFragment : OverLayFragments
    {
        public static LoadingFragment NewInstance(XOverLayControl details)
        {
            var detailsFrag = new LoadingFragment
            {
                Arguments = new Bundle(),
                ViewDetails = details
            };
            return detailsFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var view = inflater.Inflate(Resource.Layout.LoadingLayout, null);

            var activity = Xamarin.Forms.Forms.Context as Activity;
            SetView(view, activity);
            return view;
        }
    }

}