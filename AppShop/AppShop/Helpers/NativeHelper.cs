using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;

namespace AppShop.Helpers
{
    internal class NativeHelper : INativeHelper
    {
        public void CloseApp()
        {
            Process.GetCurrentProcess().CloseMainWindow();
            Process.GetCurrentProcess().Close();
        }
    }
}
