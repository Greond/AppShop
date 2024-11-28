using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using AppShop.DataBase.DataModels;
using AppShop.DataBase;
using System.Threading.Tasks;

namespace AppShop.Pages.SearchPageFolder
{
    class SearchPageViewModel : BaseViewModel
    {
        public SearchPageViewModel()
        {
             LoadPageCommand.Execute(this);
        }
        private IEnumerable<ItemCategory> _Categories;
        public IEnumerable<ItemCategory> Categories
        {
            get
            {
                return _Categories;
            }
            private set
            {
                _Categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        private ICommand _LoadPageCommand;
        public ICommand LoadPageCommand
        {
            get
            {
                return _LoadPageCommand ??
                    (_LoadPageCommand = new MvvmHelpers.Commands.Command(async () =>
                    {
                        Task task = LoadData();
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            await App.Current.MainPage.DisplayAlert("загрузка страницы", "Успешно", "Ок");
                        }
                    }));
            }
        }
        private bool _IsRefreshing;
        public bool IsRefreshing 
        {
            get { return _IsRefreshing; }
            set { _IsRefreshing = value; 
                OnPropertyChanged(nameof(IsRefreshing)); }
        }
        private async Task LoadData()
        {
            IsRefreshing = true;
            try
            {
                var Data = await WebApiConnector.GetItemsCategories();
                Categories = Data;
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
