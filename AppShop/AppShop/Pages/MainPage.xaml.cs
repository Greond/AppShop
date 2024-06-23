using AppShop.ContentView;
using AppShop.DataBase;
using AppShop.ViewEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            BindingContext = new MainPageEvent();

            ItemsDataBaseLoader itemsDataBaseLoader = new ItemsDataBaseLoader ();
            List<ItemsData> items = itemsDataBaseLoader.LoadAllStockItem();
            if (items.Count == 0) { return; }
            for (int i = 0; i < items.Count; i++)
            {
                ItemsData item = items[i];
                ActionContentView actionContentView = new ActionContentView();
                ActionLayout.Children.Add(actionContentView);
                actionContentView.TitleText = item.Name;
                actionContentView.Description = item.Description;
                actionContentView.ButtonText = "Подробнее";
                actionContentView.NewPrice = item.price.ToString();
                actionContentView.OldPrice = item.oldprice.ToString();
                actionContentView.imageSource = item.icon;
                actionContentView.IdItem = item.Id;
                actionContentView.ButtonCommandParameter = actionContentView;
                actionContentView.SetBinding(ActionContentView.ButtonCommandProperty, new Binding("ActionButtonClick"));

            }
           
            
		}

        private bool canclick = true;
        private  async void Menu_Clicked(object sender, EventArgs e)
        {
            if(!canclick) { return; }
            canclick = false;
            ImageButton btn = (ImageButton)sender;
            await btn.AnimateButtonPull();
            Shell.Current.FlyoutIsPresented = true;
            canclick = true;
            
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