﻿using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using AppShop.Helpers;
using AppShop.ContentView;
using System.Collections.Generic;
using System.Data;
using AppShop.DataBase.DataModels;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppShop.Converters;
using System.Collections;
using System.Linq;
using AppShop.DataBase;
using System.ComponentModel;
using Xamarin.Essentials;

namespace AppShop.Pages.MainPageFolder
{
    internal class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {
            
        }
        private IEnumerable<Item> _ActionViewData;  
        public  IEnumerable<Item> ActionViewData
        { get
            {
                return _ActionViewData;
            }
            private set
            {
                _ActionViewData = value;
                OnPropertyChanged("ActionViewData");
            }
        }
        private ICommand _ActionButtonClick;
        public ICommand ActionButtonClick
        {
            get
            {
                return _ActionButtonClick ??
                    (_ActionButtonClick = new MvvmHelpers.Commands.Command((obj) =>
                    {
                        ActionContentView actionContentview = obj as ActionContentView;
                        NavigationHelper.OpenItemPage("ItemPage", actionContentview.IdItem.ToString());

                    }));
            }
        }
        private ICommand _LoadPageCommand;
        public ICommand LoadPageCommand
        {
            get
            {
                return _LoadPageCommand ??
                    (_LoadPageCommand = new MvvmHelpers.Commands.Command( async () =>
                    {
                        Task task = LoadData();
                        if (task.IsCompleted)
                        {
                            await App.Current.MainPage.DisplayAlert("загрузка страницы", "Успешно", "Ок");
                        }
                    }));
            }
        }
       
        private async Task LoadData()
        {
            var Data = await WebApiConnector.GetItemsFromWebApi("Stock", "true",10);
            if(Data != null)
            {
                ActionViewData = Data;
            }

                
            
        }
    }
}
