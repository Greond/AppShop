using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShop.Views.LoginView
{
    class ViewModel : BaseViewModel
    {
        private string _Login;
        public string Login
        {
            get
            { return _Login;}
            set
            {_Login = value;}
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }



        private ICommand _LoginPageContinue;
        public ICommand LoginPageContinue
        {
            get
            {
                return _LoginPageContinue ??
                     (_LoginPageContinue = new MvvmHelpers.Commands.Command((obj) =>
                     {
                         //переход на следующую страницу
                         Shell.Current.GoToAsync("LoginPage2");
                     }));
            }
        }
        private ICommand _BackButtonClick;
        public ICommand BackButtonClick
        {
            get
            {
                return _BackButtonClick ??
                    (_BackButtonClick = new MvvmHelpers.Commands.Command((obj) =>
                    {
                        Shell.Current.GoToAsync("..");
                    }));
            }
        }
    }
}
