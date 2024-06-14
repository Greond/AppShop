using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AppShop
{
    internal static class Animations
    {
      internal async  static Task<bool> AnimateButton(this Xamarin.Forms.VisualElement self)
        {
            Task<bool> ret = new Task<bool>(() => false);
            if (!self.AnimationIsRunning(nameof(AnimateButton)))
            {
                self.BackgroundColor = Color.FromHex("E0E0E0");
                double CurrectScale = self.Scale;

               await  self.RelScaleTo(-0.10, 150, Easing.SpringIn);
               await  self.RelScaleTo(+0.15, 250, Easing.SpringOut);
               await  self.ScaleTo(CurrectScale, 300);
                return true;
            }
            return false;
        }
        internal async static Task<bool> AnimateButtonPull(this Xamarin.Forms.VisualElement self)
        {
            Task<bool> ret = new Task<bool>(() => false);
            if (!self.AnimationIsRunning(nameof(AnimateButton)))
            {
                double CurrectScale = self.Scale;

                await self.RelScaleTo(-0.10, 75 ,Easing.SinIn);
                await self.ScaleTo(CurrectScale, 25);
                return true;
            }
            return false;
        }
    }
}
