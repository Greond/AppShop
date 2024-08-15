using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShop.Pages.AboutPageFolder
{
    class ViewModel : BaseViewModel
    {
        private ICommand _MenuClicked;
        public ICommand MenuClicked
        {
            get
            {
                return _MenuClicked ??
                    (_MenuClicked = new MvvmHelpers.Commands.Command(async (obj) =>
                    {
                        if (!_MenuClicked.CanExecute(_MenuClicked)) { return; }
                        ImageButton btn = (ImageButton)obj;
                        await btn.AnimateButtonPull();
                        Shell.Current.FlyoutIsPresented = true;

                    }));
            }
        }
    }
}
