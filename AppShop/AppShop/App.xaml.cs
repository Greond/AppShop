
using AppShop.Views.Registr_View;
using AppShop.Views.RegistrView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*  MainPage = new NavigationPage(new AppShop.MainPage())
              {
                  BarBackgroundColor = Color.FromHex("E0E0E0"),
                  BarTextColor = Color.FromHex("0E0F20")

              };  */
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
