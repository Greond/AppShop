using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Helpers
{
     class NavigationHelper :NavigationPage , INavigationHelper
    {
        
        public async void OpenItemPage(string page,string itemname)
        {
          
           await Shell.Current.GoToAsync($"{page}?itemname={itemname}");

        }
        public async void CloseItemPage()
        {
            await Shell.Current.GoToAsync("..");
        }
        public new void DisplayAlert(string Title, string message, string buttontext)
        {
            DisplayAlert(Title, message, buttontext);
        }
    }
}
