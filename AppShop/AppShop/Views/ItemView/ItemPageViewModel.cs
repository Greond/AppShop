using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using AppShop.Pages;
using AppShop.DataBase;
using Xamarin.Forms;
using AppShop.DataBase.DataModels;

namespace AppShop.Views.ItemView
{
    internal class ItemPageViewModel : BaseViewModel
    {
        
        private bool _IsRefreshing;
        public bool IsRefreshing
        { get { return _IsRefreshing; } set { _IsRefreshing = value; } }

        private Item _Item;
        public Item Item {
            get { return _Item; }
            set{ 
            _Item = value;
            OnPropertyChanged(nameof(Item));
            }
        }
        private ImageSource _ItemRatingImage;
        public ImageSource ItemRatingImage { 
            get { return _ItemRatingImage; }
            set
            {
                _ItemRatingImage = value;
                OnPropertyChanged(nameof(ItemRatingImage));
            }
                
                }

        public ICommand RefreshCommand { get; set; }
        public ItemPageViewModel(ulong ID)
        {
            RefreshCommand = new MvvmHelpers.Commands.Command(() => OnRefresh());
            LoadItem(ID);
            SetData();
        }
        private void OnRefresh()
        {
           Thread thread = new Thread(async () => { await SetData(); });
           thread.Start();
        }
        protected internal async void LoadItem(ulong id)
        {

            Item = await WebApiConnector.GetItemById(id); 
        }
        private Task SetData()
        {
            IsRefreshing = true;
            try
            {
                string ratingimagesource = $"rating{Item.Stars}.png";
                ItemRatingImage = ImageSource.FromFile(ratingimagesource); //установка данных товара
                
                
                IsRefreshing = false;
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                IsRefreshing = false;
                return Task.FromException( ex );
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
        private ICommand _LikeButtonClick;
        public ICommand LikeButtonClick
        {
            get
            {
                return _LikeButtonClick ??
                    (_LikeButtonClick = new MvvmHelpers.Commands.Command((obj) =>
                    {


                    }));
            }
        }
    }
}
