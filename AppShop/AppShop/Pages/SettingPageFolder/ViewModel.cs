using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShop.Pages.SettingPageFolder
{
    internal class ViewModel : BaseViewModel
    {
        private bool _PhoneBindingTheme;
        private bool _LightTheme;
        private bool _DarkTheme;
        public ViewModel()
        {
            _PhoneBindingTheme = true;
        }
        public bool PhoneBindingTheme
        {
            get { return _PhoneBindingTheme; }
            set 
            { 
                _PhoneBindingTheme = value; 
                OnPropertyChanged(nameof(PhoneBindingTheme));
                ChangeTheme();
            }
        }
        public bool LightTheme
        {
            get => _LightTheme;
            set
            {
                _LightTheme = value;
                OnPropertyChanged(nameof(LightTheme));
                ChangeTheme();
            }
        }
        public bool DarkTheme
        {
            get { return _DarkTheme; }
            set
            {
                _DarkTheme = value;
                OnPropertyChanged(nameof(DarkTheme));
                ChangeTheme();
            }
        }

        void ChangeTheme()
        {
            if (_LightTheme)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else if (_DarkTheme)
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else if (_PhoneBindingTheme)
            {
                Application.Current.UserAppTheme = OSAppTheme.Unspecified;
            }
        }
    }
}
