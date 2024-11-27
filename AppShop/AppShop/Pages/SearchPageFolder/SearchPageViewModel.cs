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
                        if (task.IsCompleted)
                        {
                            await App.Current.MainPage.DisplayAlert("загрузка страницы", "Успешно", "Ок");
                        }
                    }));
            }
        }
        private async Task LoadData()
        {
            var Data = await WebApiConnector.GetItemsCategories();
            if (Data != null)
            {
                Categories = Data;
            }

        }
    }
}
