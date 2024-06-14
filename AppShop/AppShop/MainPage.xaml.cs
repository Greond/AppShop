using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShop.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private bool CanClick = true;
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
          if (CanClick == false) { return; }
          CanClick = false;
          ImageButton btn = ( ImageButton)sender;   
          await btn.AnimateButton();
            CanClick = true;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (!CanClick) { return; }
            CanClick = false;
            ImageButton btn = (ImageButton)sender;
            btn.BackgroundColor = Color.FromHex("E0E0E0");
            double CurrectScale = btn.Scale;

            await btn.RelScaleTo(-0.10, 150, Easing.SpringIn);
            await btn.RelScaleTo(+0.15, 250, Easing.SpringOut);
            await btn.ScaleTo(CurrectScale, 300);
            CanClick = true;
        }
    }
}