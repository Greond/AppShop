using System;
using System.Windows.Input;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace AppShop.ContentView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionContentView : Xamarin.Forms.ContentView
    {

        public static readonly BindableProperty IdItemProperty =
            BindableProperty.Create("IdItem", typeof(string), typeof(ActionContentView), default(string));
        public string IdItem
        {
            get { return (string)GetValue(IdItemProperty); }
            set { SetValue(IdItemProperty, value); }
        }

        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create("TitleText", typeof(string), typeof(ActionContentView), default(string));

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty DesciptionProperty =
           BindableProperty.Create("Description", typeof(string), typeof(ActionContentView), default(string));

        public string Description
        {
            get { return (string)GetValue(DesciptionProperty); }
            set { SetValue(DesciptionProperty, value); }
        }

        public static readonly BindableProperty ButtonTextProperty =
          BindableProperty.Create("ButtonText", typeof(string), typeof(ActionContentView), default(string));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly BindableProperty NewPriceProperty =
           BindableProperty.Create("NewPrice", typeof(string), typeof(ActionContentView), default(string));

        public string NewPrice
        {
            get { return (string)GetValue(NewPriceProperty); }
            set { SetValue(NewPriceProperty, value); }
        }

        public static readonly BindableProperty OldPriceProperty =
          BindableProperty.Create("OldPrice", typeof(string), typeof(ActionContentView), default(string));

        public string OldPrice
        {
            get { return (string)GetValue(OldPriceProperty); }
            set { SetValue(OldPriceProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create("imageSource", typeof(ImageSource), typeof(ActionContentView), default(ImageSource));
        public ImageSource imageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly BindableProperty ButtonCommandProperty =
      BindableProperty.Create(
      "ButtonCommand", typeof(ICommand), typeof(ActionContentView),
          defaultValue: null);

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public static readonly BindableProperty ButtonCommandParameterProperty =
            BindableProperty.Create("ButtonCommandParameter",typeof(object), typeof(ActionContentView),defaultValue: null);
        public object ButtonCommandParameter
        {
            get { return (object)GetValue(ButtonCommandParameterProperty); }
            set { SetValue(ButtonCommandParameterProperty, value);}
        }
        public ActionContentView()
        {
            InitializeComponent();
            ActionButton.SetBinding(Button.TextProperty, new Binding (nameof(ButtonText), source: this));
            LabelOldPrice.SetBinding(Label.TextProperty,new Binding(nameof(OldPrice), source: this));
            LabelNewPrice.SetBinding(Label.TextProperty, new Binding(nameof(NewPrice), source: this));
            LabelDescription.SetBinding(Label.TextProperty, new Binding(nameof(Description), source: this));
            LabelTitle.SetBinding(Label.TextProperty, new Binding (nameof(TitleText), source: this));
            ActionButton.SetBinding(Button.CommandProperty, new Binding (nameof(ButtonCommand), source: this));
            ActionButton.SetBinding(Button.CommandParameterProperty, new Binding(nameof(ButtonCommandParameter), source: this));
           
        }

        private async void ActionButton_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await button.AnimateButton();
            
        }
    }
}