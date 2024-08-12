using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.ContentView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagesHeader : Xamarin.Forms.ContentView
	{
        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create("TitleText", typeof(string), typeof(CategoryItemView), default(string));

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }
        public PagesHeader ()
		{
            
            InitializeComponent ();
        }
        private ICommand _MenuClicked;
        public ICommand MenuClicked
        {
            get
            {
                return _MenuClicked ??
                    (_MenuClicked = new MvvmHelpers.Commands.Command(async (obj) =>
                    {
                        if (!_MenuClicked.CanExecute(_MenuClicked)) { return; }
                        ImageButton btn = (ImageButton)obj;
                        await btn.AnimateButtonPull();
                        Shell.Current.FlyoutIsPresented = true;

                    }));
            }
        }
    }
}