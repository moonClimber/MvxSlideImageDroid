using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvxSlideImage.Core.ViewModels;
using MvxSlideImage.Droid.Presenter;

namespace MvxSlideImage.Droid.Views
{
    [Activity(Label = "Mvx Slide Image (Droid)",
     NoHistory = true,
     ScreenOrientation = ScreenOrientation.Portrait,
     HardwareAccelerated = false,
     Icon = "@drawable/Icon")]
    public class StartView: MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StartView);

            var presenter = (DroidPresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            var firstFragment = new FirstView() { ViewModel = new FirstViewModel() };
            presenter.RegisterFragmentManager(this.SupportFragmentManager, firstFragment);
        }
    }
}