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
                    (_ActionButtonClick = new Command( (obj) =>
                    {
                        NavigationHelper navigationHelper = new NavigationHelper();
                        ActionContentView actionContentview = obj as ActionContentView;
                        navigationHelper.OpenItemPage("ItemPage",actionContentview.IdItem.ToString());
                        
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
