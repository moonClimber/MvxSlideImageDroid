using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MvxSlideImage.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        public SecondViewModel()
        {
            SecondText = "Lorem Ipsum";
        }

        private string _secondText;
        public string SecondText
        {
            get { return _secondText; }
            set
            {
                _secondText = value;
                RaisePropertyChanged(() => SecondText);
            }
        }


        private MvxCommand _goBackCommand   ;
        public ICommand GoBack
        {
            get
            {
                _goBackCommand = _goBackCommand ?? new MvxCommand(DoGoBack);
                return _goBackCommand;
            }
        }
        private void DoGoBack()
        {
            Close(this);
        }

    }
}
