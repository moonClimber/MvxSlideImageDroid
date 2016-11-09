using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvxSlideImage.Droid.Presenter;

namespace MvxSlideImage.Droid.Views
{
    [Activity(Label = "",
         NoHistory = true,
         ScreenOrientation = ScreenOrientation.Portrait,
         HardwareAccelerated = false,
         Icon = "@drawable/Icon")]
    public class FirstView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);


            var presenter = (DroidPresenter) Mvx.Resolve<IMvxAndroidViewPresenter>();
            var firstFragment = new FirstFragment() {ViewModel = ViewModel};
            presenter.RegisterFragmentManager(this.SupportFragmentManager, firstFragment);
        }
    }
}
