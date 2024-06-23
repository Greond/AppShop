using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Helpers
{
    interface INavigationHelper
    {
        void OpenItemPage(string page,string itemname);
        void CloseItemPage();
        void DisplayAlert(string Title, string message,string buttontext);
    }
}
