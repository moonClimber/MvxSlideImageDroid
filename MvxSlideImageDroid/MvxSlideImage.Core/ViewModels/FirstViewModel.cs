using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MvxSlideImage.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }


        private MvxCommand _gotoNextCommand;
        public ICommand GotoNext
        {
            get
            {
                _gotoNextCommand = _gotoNextCommand ?? new MvxCommand(DoGotoNext);
                return _gotoNextCommand;
            }
        }
        private void DoGotoNext()
        {
            ShowViewModel<SecondViewModel>();
        }

    }
}
