using AppShop.Helpers;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Essentials;
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
            ChangedUrl = Preferences.Get("BaseUrl", "не установленно");
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
        private string _changedUrl;
        public string ChangedUrl
        {
            get { return _changedUrl; }
            set { 
                _changedUrl = value;
                OnPropertyChanged(nameof(ChangedUrl));
            }
        }
        private ICommand _saveNewUrl;
        public ICommand SaveNewUrl
        {
            get
            {
                return _saveNewUrl ??
                    (_saveNewUrl = new MvvmHelpers.Commands.Command(async () =>
                    {
                        Preferences.Set("BaseUrl", ChangedUrl);
                        var result = await App.Current.MainPage.DisplayAlert("Новый url сохранен","Требуется перезагрузка приложеия. \nПерезагрузить сейчас?","Завершить работу","Остаться");
                        if(result)
                        {
                            INativeHelper nativeHelper = new NativeHelper();
                            nativeHelper.CloseApp();
                        }
                    }));
            }
        }

    }
}
