using Android.Content.Res;

namespace MvxSlideImage.Droid.Common
{
    public static class DimensionHelper
    {
        public static int DpToPx(int dp)
        {
            return (int) (dp*Resources.System.DisplayMetrics.Density);
        }

        public static int PxToDp(int px)
        {
            return (int) (px/Resources.System.DisplayMetrics.Density);
        }
    }
}