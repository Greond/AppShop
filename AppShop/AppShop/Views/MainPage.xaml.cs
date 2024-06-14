using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShop.Helpers;
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
		}
		private bool canclick = true;
        private  async void Menu_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            await btn.AnimateButtonPull();
            Shell.Current.FlyoutIsPresented = true;
        }

        private void Menu_Pressed(object sender, EventArgs e)
        {

        }

        private void Menu_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}