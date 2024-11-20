using AppShop.ContentView;
using AppShop.DataBase;
using AppShop.DataBase.DataModels;
using AppShop.Pages.MainPageFolder;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        static MainPageViewModel ViewModel { get; set; }
		public MainPage ()
		{
			InitializeComponent ();

            ViewModel = new MainPageFolder.MainPageViewModel();
            BindingContext = ViewModel;
            ViewModel.LoadPageCommand.Execute(this);

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //ActionContent.ItemsSource = await App.ItemsDB.GetItemsAsync();
            
        }
        private void Menu_Pressed(object sender, EventArgs e)
        {

        }

        private void Menu_Focused(object sender, FocusEventArgs e)
        {

        }

        private async void ViewsItem1_Tapped(object sender, EventArgs e)
        {
            CategoryItemView categoryItemView = (CategoryItemView)sender;
            string output = string.Empty;
            if (categoryItemView == item1)
            { output = "item one"; }
            if (categoryItemView == item2) { output = "item two"; }
            await categoryItemView.AnimateButton();
            await DisplayAlert("test", output + " was clicked", "YESSS");
        }
    }
}