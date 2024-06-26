using AppShop.DataBase;
using AppShop.Views.ItemView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[QueryProperty(nameof(ItemId), "itemid")]
	public partial class ItemPage : ContentPage
	{
        public ItemPage()
        {
            InitializeComponent();
        }
        public string ItemId
        {
            set
            {
                LoadItem(value);
            }
        }
		private void LoadItem(string _ItemId)
		{
			try
			{
			   ItemsDataBaseLoader loader = new ItemsDataBaseLoader();
                ItemPageViewModel ItemViewModel = new ItemPageViewModel(); 
                ItemViewModel.loadData(loader.LoadItem(Convert.ToInt64(_ItemId)));
			}
			catch { Console.WriteLine("ItemLoadEror"); }
          
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}