using Android.App;
using Xamarin.Forms;
using App2.Droid.ShowPopup;
using App2.ShowPopup;

[assembly: Dependency(typeof(ShowOverlay))]
namespace App2.Droid.ShowPopup
{
    public class ShowOverlay : IShowOverLay
    {
        private readonly string LoadingOverLay = "loading";

        private static Activity Current => Forms.Context as Activity;

        public void HideAll()
        {
            using (var manager = Current.FragmentManager.BeginTransaction())
            {
                if (HideAll(manager, ""))
                {
                    manager.Commit();
                }
            }
        }

        public void HideAll(string keepOverlay)
        {
            using (var manager = Current.FragmentManager.BeginTransaction())
            {
                if (HideAll(manager, keepOverlay))
                {
                    manager.Commit();
                }
            }
        }

        private bool HideAll(FragmentTransaction manager, string keepOverlay)
        {
            var found = false;
            if (keepOverlay != LoadingOverLay)
            {
                var frag = Current.FragmentManager.FindFragmentByTag(LoadingOverLay);
                if (frag != null)
                {
                    manager.Remove(frag);
                    found = true;
                }
            }
            
            return found;
        }

        public void ShowLoadingScreen(XOverLayControl details)
        {
            if (IsActive(LoadingOverLay) == false)
            {
                var frag = LoadingFragment.NewInstance(details);
                using (var manager = Current.FragmentManager.BeginTransaction())
                {
                    manager.Add(Android.Resource.Id.Content, frag, LoadingOverLay);
                    HideAll(manager, LoadingOverLay);
                    manager.Commit();
                }
            }
        }

        private static bool IsActive(string overlay)
        {
            var activity = Forms.Context as Activity;
            var f = activity?.FragmentManager.FindFragmentByTag(overlay);
            return f != null;
        }

        public bool CanRun => true;
    }

}