using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.ContentView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmptyView : Xamarin.Forms.ContentView
	{
		public EmptyView ()
		{
			InitializeComponent ();
		}
	}
}