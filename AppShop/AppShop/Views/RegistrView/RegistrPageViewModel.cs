using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShop.Views.Registr_View
{
    class RegistrPageViewModel : BaseViewModel
    {
        private ICommand _ClearButtonClick;
        public ICommand ClearButtonClick
        {
            get
            {
                return _ClearButtonClick ??
                    (_ClearButtonClick = new MvvmHelpers.Commands.Command((obj) =>
                    {

                    }));
            }
        }

        private ICommand _SaveButtonClick;
        public ICommand SaveButtonClick
        {
            get
            {
                return _SaveButtonClick ??
                    (_SaveButtonClick = new MvvmHelpers.Commands.Command((obj) =>
                    {
                       
                        List<string> list = new List<string>();
                        list.Add(Login);
                        list.Add(Email);
                        list.Add(Password);
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

        private string _Login;
        public string Login
        { get { return _Login; } set { _Login = value; } }

        private string _Email;
        public string Email
        { get { return _Email; } set { _Email = value; } }

        private string _Password;
        public string Password
        { get { return _Password; } set { _Password = value; } }
    }
}
