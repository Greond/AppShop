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

namespace AppShop.Views.ItemView
{
    internal class ItemPageViewModel : BaseViewModel
    {
        
        private bool _IsRefreshing;
        public bool IsRefreshing
        { get { return _IsRefreshing; } set { _IsRefreshing = value; } }

        private ItemsData _Item;
        public ItemsData Item {
            get { return _Item; }
            set{ 
            _Item = value;
            OnPropertyChanged();
            }
        }
        private ImageSource _ItemRatingImage;
        public ImageSource ItemRatingImage { 
            get { return _ItemRatingImage; }
            set
            {
                _ItemRatingImage = value;
                OnPropertyChanged();
            }
                
                }

        public ICommand RefreshCommand { get; set; }
        public ItemPageViewModel(string ID)
        {
            RefreshCommand = new MvvmHelpers.Commands.Command(() => OnRefresh());
            SetItem(ID);
            loadData();
        }
        private void OnRefresh()
        {
           //  Thread thread = new Thread(async () => { await loadData(); });
            // thread.Start();
        }
        protected internal void SetItem(string id)
        {
            ItemsDataBaseLoader Loader = new ItemsDataBaseLoader();

            ItemsData item = Loader.LoadItem(id);
            Item = item;
        }
        public  Task loadData()
        {
            IsRefreshing = true;
            try
            {
                string ratingimagesource = $"rating{Item.Stars}.png";
                ItemRatingImage = ImageSource.FromFile(ratingimagesource);
                
                
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
