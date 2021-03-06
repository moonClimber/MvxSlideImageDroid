using System;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace MvxSlideImage.Droid.Presenter
{
    // http://gregshackles.com/presenters-in-mvvmcross-navigating-android-with-fragments/
    public class DroidPresenter : MvxAndroidViewPresenter
    {
        private readonly IFragmentTypeLookup _fragmentTypeLookup;
        private readonly IMvxViewModelLoader _viewModelLoader;
        private FragmentManager _fragmentManager;
        

        public DroidPresenter(IMvxViewModelLoader viewModelLoader, IFragmentTypeLookup fragmentTypeLookup)
        {
            _fragmentTypeLookup = fragmentTypeLookup;
            _viewModelLoader = viewModelLoader;
        }

        public void RegisterFragmentManager(FragmentManager fragmentManager, MvxFragment initialFragment)
        {
            _fragmentManager = fragmentManager;

            ShowFragment(initialFragment, false);
        }


        public void Show(MvxViewModelRequest request, bool addToBackStack)
        {
            Type fragmentType;
            if ((_fragmentManager == null) ||
                !_fragmentTypeLookup.TryGetFragmentType(request.ViewModelType, out fragmentType))
            {
                base.Show(request);

                return;
            }

            var fragment = (MvxFragment)Activator.CreateInstance(fragmentType);
            fragment.ViewModel = _viewModelLoader.LoadViewModel(request, null);

            ShowFragment(fragment, addToBackStack);
        }

        public override void Show(MvxViewModelRequest request)
        {
            Show(request, true);
        }

        private void ShowFragment(MvxFragment fragment, bool addToBackStack)
        {
            var transaction = _fragmentManager.BeginTransaction();

            if (addToBackStack)
                transaction.AddToBackStack(fragment.GetType().Name);

            transaction
                .Replace(Resource.Id.contentFrame, fragment)
                .Commit();
        }


        public override void Close(IMvxViewModel viewModel)
        {
            var currentFragment = _fragmentManager.FindFragmentById(Resource.Id.contentFrame) as MvxFragment;
            if ((currentFragment != null) && (currentFragment.ViewModel == viewModel))
            {
                _fragmentManager.PopBackStackImmediate();

                return;
            }

            base.Close(viewModel);
        }
        
    }
}