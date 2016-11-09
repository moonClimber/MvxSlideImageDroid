using Android.OS;
using Android.Views;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Views;
using FFImageLoading.Work;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvxSlideImage.Droid.Common;

namespace MvxSlideImage.Droid.Views
{
    public class ImageFragment : MvxFragment
    {
        private int _position;
        private ImageViewAsync _imgDisplay;

        public ImageFragment(int position = 0)
        {
            this._position = position;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.ImageFragment, null);
            _imgDisplay = view.FindViewById<ImageViewAsync>(Resource.Id.imgDisplay);
            var urlToImage = GalleryRepository.Images[_position];

            ImageService.Instance.LoadUrl(urlToImage)
                .Retry(3, 200)
                .DownSample(300, 300)
                //.Transform(new CircleTransformation())
                .Transform(new GrayscaleTransformation())
                .LoadingPlaceholder(Config.LoadingPlaceholderPath, ImageSource.ApplicationBundle)
                .ErrorPlaceholder(Config.ErrorPlaceholderPath, ImageSource.ApplicationBundle)
                .Into(_imgDisplay);

            return view;
        }

        public override void OnDestroyView()
        {
            if (_imgDisplay != null)
            {
                _imgDisplay.Dispose();
                _imgDisplay = null;
            }
            base.OnDestroyView();
        }
    }
}