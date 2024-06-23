using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using AppShop.Helpers;
using AppShop.Views;
using Xamarin.Forms;
using AppShop;
using AppShop.ContentView;

namespace AppShop.ViewEvent
{
    class MainPageEvent : INotifyPropertyChanged
    {
        private ICommand _ActionButtonClick;
        public ICommand ActionButtonClick
        {
            get
            {
                return _ActionButtonClick ??
                    (_ActionButtonClick = new Command<Object>(async obj =>
                    {
                        NavigationHelper navigationHelper = new NavigationHelper();
                        Button button = (Button)obj;
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
