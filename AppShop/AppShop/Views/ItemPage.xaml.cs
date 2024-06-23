using AppShop.DataBase;
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
	public partial class ItemPage : NavigationPage
	{
        public ItemPage()
        {
            InitializeComponent();
            
        }
        public string ItemId
        {
            set
            {
                LoadPage(value);
            }
        }
        private ItemsData PageItem;
		private void LoadPage(string _ItemId)
		{
			try
			{
			   ItemsDataBaseLoader loader = new ItemsDataBaseLoader();
			  PageItem = loader.LoadItem(Convert.ToInt64(_ItemId));
                
			}
			catch { Console.WriteLine("ItemLoadEror"); }
          
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}