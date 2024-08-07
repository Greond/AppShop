using AppShop.Pages.SettingPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();
		}

		private void ThemeChanged(object sender, CheckedChangedEventArgs e)
		{
			ViewModel viewModel = new ViewModel();
		
		}
	}
}