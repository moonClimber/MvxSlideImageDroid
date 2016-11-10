using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvxSlideImage.Droid.Common;

namespace MvxSlideImage.Droid.Views
{
    public class FirstView : MvxFragment
    {
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.FirstView, null);
            
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitializeViewPager(view, 0);
        }

        private void InitializeViewPager(View view, int position)
        {
            var viewPager = view.FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.SetClipToPadding(false);
            viewPager.PageMargin = DimensionHelper.DpToPx(12);

            // in production environment, images have to be loaded from ViewModel

            // Note: user ChildFragmentManager instead of FragmentManager. By this way the ViewPager is there after a back as well.
            // See: http://stackoverflow.com/questions/32560394/viewpager-data-lost-when-coming-back-from-next-screen
            viewPager.Adapter = new SwipeGalleryStateAdapter(ChildFragmentManager, GalleryRepository.Images);
            viewPager.SetCurrentItem(position, false);
        }
    }
}