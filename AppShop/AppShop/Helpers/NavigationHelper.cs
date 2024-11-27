using AppShop.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Helpers
{
     class NavigationHelper :NavigationPage //, INavigationHelper
    {
        
        public static async void OpenItemPage(string page,string IdItem)
        {
            await Shell.Current.GoToAsync($"{page}?itemid={IdItem}");
        }
        public static async void ClosePage()
        {
            await Shell.Current.GoToAsync("..");
        }
        public static new async void DisplayAlert(string Title, string message, string buttontext)
        {
            await Application.Current.MainPage.DisplayAlert(Title, message, buttontext);
        }
    }
}
