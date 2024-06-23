using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[QueryProperty(nameof(ItemName), "itemname")]
	public partial class ItemPage : ContentPage
	{
		string ItemName {
			set {  }
		}
		public ItemPage ()
		{
			InitializeComponent ();
		}
		void LoadItem(string itemName)
		{
			
			try
			{
				lebel.Text = itemName;
			}
			catch { Console.WriteLine("ItemLoadEror"); }
		}
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}