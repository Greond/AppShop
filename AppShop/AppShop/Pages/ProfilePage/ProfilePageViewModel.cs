using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace AppShop.Pages.ProfilePage
{
    internal class ProfilePageViewModel : BaseViewModel
    {
        private ICommand _OpenRegistrView;
        public ICommand OpenRegistrView
        {
            get
            {
                return _OpenRegistrView ??
                    (_OpenRegistrView = new MvvmHelpers.Commands.Command((obj) =>
                    {
                        Shell.Current.GoToAsync("RegistrPage");
                    }));
            }
        }

        private ICommand _OpenLoginView;
        public ICommand OpenLoginView
        {
            get
            {
                return _OpenLoginView ??
                    (_OpenLoginView = new MvvmHelpers.Commands.Command((obj) =>
                    {
                        //open login view
                        Shell.Current.GoToAsync("LoginPage");
                    }));
            }
        }
        private ICommand _MenuClicked;
        public ICommand MenuClicked
        {
            get
            {
                return _MenuClicked ??
                    (_MenuClicked = new MvvmHelpers.Commands.Command(async(obj) =>
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
