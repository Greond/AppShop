using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Helpers
{
     class TextConvertHelper
    {
        public static string[] TextToList(string Text, string Seperator)
        {
            string[] list = Text.Split(Seperator, StringSplitOptions.RemoveEmptyEntries);
            return list;
        }
    }
}
