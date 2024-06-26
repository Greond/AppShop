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
        private string _ItemName;
        public string ItemName
        { get { return _ItemName; } set { _ItemName = value; } }
        public ImageSource StarsImage {
            get; set;
        }
        private bool _IsRefreshing;
        public bool IsRefreshing
        { get { return _IsRefreshing; } set { _IsRefreshing = value; } }

        public ICommand RefreshCommand { get; set; }
        public ItemPageViewModel()
        {

            RefreshCommand = new MvvmHelpers.Commands.Command(() => OnRefresh());

        }
        private void OnRefresh()
        {
           //  Thread thread = new Thread(async () => { await loadData(); });
            // thread.Start();
        }
        public  Task loadData(ItemsData PageItem)
        {
            IsRefreshing = true;
            try
            {
                ItemName = PageItem.Name;
                StarsImage = ImageSource.FromFile($"rating{PageItem.stars}.png");
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
