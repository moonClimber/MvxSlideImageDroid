using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using MvxSlideImage.Droid.Views;

namespace MvxSlideImage.Droid.Common
{
    public class SwipeGalleryStateAdapter : FragmentStatePagerAdapter
    {
        private List<string> images;

        public SwipeGalleryStateAdapter(Android.Support.V4.App.FragmentManager fm, List<string> images) : base(fm)
        {
            this.images = images;
        }

        public override int Count
        {
            get { return images.Count; }
        }

        public override float GetPageWidth(int position)
        {
            return 0.93f;
        }

        public override Fragment GetItem(int position)
        {
            ImageFragment f = new ImageFragment(position);
            return f;
        }
    }
}