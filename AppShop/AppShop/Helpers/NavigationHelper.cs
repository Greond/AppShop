using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Helpers
{
     class NavigationHelper :NavigationPage , INavigationHelper
    {
        
        public async void OpenItemPage(string page,string IdItem)
        {
          
           await Shell.Current.GoToAsync($"{page}?itemid={IdItem}");

        }
        public async void ClosePage()
        {
            await Shell.Current.GoToAsync("..");
        }
        public new void DisplayAlert(string Title, string message, string buttontext)
        {
            DisplayAlert(Title, message, buttontext);
        }
    }
}
