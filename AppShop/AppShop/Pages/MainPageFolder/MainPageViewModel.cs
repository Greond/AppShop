using MvvmHelpers;
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
using SQLitePCL;

namespace AppShop.Pages.MainPageFolder
{
    internal class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {
            LoadPageCommand.Execute(this); // Load  data
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
                    (_LoadPageCommand = new MvvmHelpers.Commands.Command(() =>
                    {
                        Task task = LoadData();
                    }));
            }
        }
        private bool _IsRefreshing;
        public bool IsRefreshing { 
            get
            {
                return _IsRefreshing;
            }
             set
            {
                _IsRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        private async Task LoadData() // load data to page
        {
            IsRefreshing = true;
            try
            {
                var Data = await WebApiConnector.GetItemsFromWebApi("Stock", "true", 10);
                ActionViewData = Data;
                await App.Current.MainPage.DisplayAlert("загрузка страницы", "Успешно", "Ок");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("загрузка страницы", $"{ex.Message}", "Ок");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
