using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop.ContentView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryItemView : Xamarin.Forms.ContentView
	{
		public static readonly BindableProperty TitleTextProperty =
			BindableProperty.Create("TitleText", typeof(string), typeof(CategoryItemView), default(string));

		public string TitleText
		{
			get { return (string)GetValue(TitleTextProperty); }
			set { SetValue(TitleTextProperty, value); }
		}

		public event EventHandler clicked;
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create("Command", typeof(ICommand), typeof(CategoryItemView), null);
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create("CommandParameter", typeof(Object), typeof(CategoryItemView), null);
		public Object CommandParameter
		{
			get {return (Object)GetValue(CommandParameterProperty); }
			set {SetValue(CommandParameterProperty, value); }
        }
        public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create("Source", typeof(ImageSource), typeof(CategoryItemView), default(ImageSource));
		public ImageSource Source
		{
			get { return (ImageSource)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value);}
        }
        public CategoryItemView ()
		{
			InitializeComponent ();
			this.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					clicked?.Invoke(this, EventArgs.Empty);
					if (Command != null)
					{
						if (Command.CanExecute(CommandParameter))
							Command.Execute(CommandParameter);
					}
				})
			});
		}
    }
}