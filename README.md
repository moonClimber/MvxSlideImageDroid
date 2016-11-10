# MvxSlideImageDroid
Very simple app for using MvvCross with FFImageLoading, PageAdapter, Fragment on Android

This project comes from different sources and its target is to merge all those sources into a unique project based on MvvmCross framework.
Particularly, the objective is to run the PageView (a sort of PaheHub in Windows Phone) in Android, with a smart image control that can load images from an url and manage automatically a local cache.

Here are the sources:
* http://gregshackles.com/presenters-in-mvvmcross-navigating-android-with-fragments/: this is not actually a mandatory component of the project, but it was useful for me to have this block. You can just ignore it by commenting a couple of methods in Setup.cs file: CreateViewPresenter and InitializeIoC
* https://github.com/luberda-molinet/FFImageLoading: this is the main component from which I've derived the primary structure of this sample app (see samples)
* https://github.com/MvvmCross/MvvmCross-AndroidSupport: this is the fundamental component that makes everything working. It allows to work with fragment and Xamarin Support Library

Here are some screenshots of the scrolling behavior
![First image](/mvx_Img001.png)|![Scrolling between first and second image](/mvx_Img002.png)|![Third image](/mvx_Img002.png)