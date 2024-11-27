using AppShop.DataBase;
using AppShop.Views.ItemView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppShop.Views
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
                LoadItem(Convert.ToUInt64(value));
            }
        }
		private void LoadItem(ulong _ItemId)
		{
			try
			{
                ItemPageViewModel PageViewModel = new ItemPageViewModel(_ItemId); 
                BindingContext = PageViewModel;
                PageViewModel.LoadPageCommand.Execute(this);
			}
			catch { Debug.WriteLine("ItemLoadEror"); }
          
        }
    }
}