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
using AppShop.Helpers;

namespace AppShop.Views.ItemView
{
    internal class ItemPageViewModel : BaseViewModel
    {
        //Item DATA
        private Item _Item;
        public Item Item {
            get { return _Item; }
            set{ 
            _Item = value;
            OnPropertyChanged(nameof(Item));
            }
        }
        private ImageSource _ItemRatingImage;
        public ImageSource ItemRatingImage 
        { 
            get { return _ItemRatingImage; }
            set
            {
                _ItemRatingImage = value;
                OnPropertyChanged(nameof(ItemRatingImage));
            }
        }
        private IEnumerable<string> _ItemSpecifications;
        public IEnumerable<string> ItemSpecifications {
            get { return _ItemSpecifications;   }
            set { 
                _ItemSpecifications = value;
                OnPropertyChanged( nameof(ItemSpecifications));
            }
        }
        
        private string _ItemMainDescripion;
        public string ItemMainDescripion
        {
            get { return _ItemMainDescripion; }
            set
            {
                _ItemMainDescripion = value;
                OnPropertyChanged(nameof(ItemMainDescripion));
            }
        }
        private object _ItemReviews;
        public object ItemReviews
        {
            get { return _ItemReviews; }
            set
            {
                _ItemReviews = value;
                OnPropertyChanged(nameof(ItemReviews));
            }
        }
        //Item DATA end
        //Data Load
        private bool _IsRefreshing;
        public bool IsRefreshing
        { get { return _IsRefreshing; } set { _IsRefreshing = value; } }
        public ICommand LoadPageCommand { get; set; }
        public ItemPageViewModel(ulong ID)
        {
            LoadPageCommand = new MvvmHelpers.Commands.Command(() => LoadPage(ID)); // fisrt load 
        }
        private async void LoadPage(ulong id)
        {
            if (IsRefreshing)
            { return; }
            IsRefreshing = true;
            Item = await WebApiConnector.GetItemById(id); // Load Item From Web
            await SetData();
            IsRefreshing = false;

        }
        private Task SetData()//установка данных товара
        {
            try
            {
                string ratingimagesource = $"rating{Item.Stars}.png";
                ItemRatingImage = ImageSource.FromFile(ratingimagesource);
                ItemSpecifications = TextConvertHelper.TextToList(Item.Specifications, "|");
                ItemMainDescripion = Item.MainDescription;
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException( ex );
            }
        }
        //Data load end
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
