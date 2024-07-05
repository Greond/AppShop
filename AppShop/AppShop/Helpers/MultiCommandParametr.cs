using AppShop.ContentView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Views.Registr_View
{
    class MultiCommandParametr : Xamarin.Forms.ContentView
    {
        public static readonly BindableProperty CommandParameterProperty =
      BindableProperty.Create("CommandParameter", typeof(Object), typeof(MultiCommandParametr), null);
        public Object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly BindableProperty CommandParameterProperty1 =
      BindableProperty.Create("CommandParameter", typeof(Object), typeof(MultiCommandParametr), null);
        public Object CommandParameter1
        {
            get { return (Object)GetValue(CommandParameterProperty1); }
            set { SetValue(CommandParameterProperty1, value); }
        }
        public static readonly BindableProperty CommandParameterProperty2 =
      BindableProperty.Create("CommandParameter", typeof(Object), typeof(MultiCommandParametr), null);
        public Object CommandParameter2
        {
            get { return (Object)GetValue(CommandParameterProperty2); }
            set { SetValue(CommandParameterProperty2, value); }
        }
    }
}
