using AppShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using AppShop.Pages;
using AppShop.Views;

namespace AppShop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell : Shell
	{
		public AppShell ()
		{
			InitializeComponent ();
			Routing.RegisterRoute("ItemPage", typeof(ItemPage));
		}
		public ICommand ExitCommand => new Command(() =>
		{
			Application.Current.Quit();
		});
        private  void ExitItem_Clicked(object sender, EventArgs e)
        {
			NativeHelper nativeHelper = new NativeHelper();
			nativeHelper.CloseApp();

        }
    }
}