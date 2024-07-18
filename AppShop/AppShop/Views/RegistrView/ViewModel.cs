using AppShop.Helpers;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShop.Views.RegistrView
{
    class ViewModel : BaseViewModel
    {
        private ICommand _ClearButtonClick;
        // test
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

        private ICommand _RegistrPageButtonNextClick;
        public ICommand RegistrPageButtonNextClick
        {
            get
            {
                return _RegistrPageButtonNextClick ??
                    (_RegistrPageButtonNextClick = new MvvmHelpers.Commands.Command((obj) =>
                    {
                       //Save Data to DataBase
                       
                        // Comon to Next Password Page
                        Shell.Current.GoToAsync("PasswordPage");
                    }));
            }
        }
        private ICommand _SaveData;
        public ICommand SaveData
        {
            get
            {
                return _SaveData ??
                    (_SaveData = new MvvmHelpers.Commands.Command((obj) =>
                    {
                        //Save Data to DataBase

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

        private Task<bool> SaveUserData(string Login, string Email, string Password)
        {
            return Task.FromResult(true);  
        }
    }
}
