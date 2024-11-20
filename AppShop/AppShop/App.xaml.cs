
using AppShop.Views.Registr_View;
using AppShop.Views.RegistrView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppShop.DataBase;
using System.Net.Http.Headers;
using System.IO;

namespace AppShop
{
    public partial class App : Application
    {
        static ItemsDB itemsDB;
        public static ItemsDB ItemsDB
        {
            get
            {
                if (itemsDB  == null)
                {
                    itemsDB = new ItemsDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"LocalDataBase.db3"));
                }
                return itemsDB;
            }
        }
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
