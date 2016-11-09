using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvxSlideImage.Droid.Common;


namespace MvxSlideImage.Droid.Views
{
    public class FirstFragment : MvxFragment
    { 
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.FirstFragment, null);
            InitializeViewPager(view, 0);
            return view;
        }

        private void InitializeViewPager(View view, int position)
        {
            

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.SetClipToPadding(false);
            viewPager.PageMargin = DimensionHelper.DpToPx(12);

            // in production environment, images have to be loaded from ViewModel
            viewPager.Adapter = new SwipeGalleryStateAdapter(this.FragmentManager, GalleryRepository.Images);
            viewPager.SetCurrentItem(position, false);  
        }
    }
}