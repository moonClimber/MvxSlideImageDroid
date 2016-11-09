using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MvxSlideImage.Droid.Presenter
{
    // http://gregshackles.com/presenters-in-mvvmcross-navigating-android-with-fragments/
    public interface IFragmentTypeLookup
    {
        bool TryGetFragmentType(Type viewModelType, out Type fragmentType);
    }
}