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
                ItemPageViewModel PageViewModel = new ItemPageViewModel(_ItemId); 
                BindingContext = PageViewModel;
			}
			catch { Console.WriteLine("ItemLoadEror"); }
          
        }
    }
}