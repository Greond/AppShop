using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Converters
{
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null || parameter.ToString() == string.Empty)
            {
                return null;
            }
            string cardNum = value.ToString();
            int cardInt = 3;

            while (cardInt < cardNum.Length)
            {
                cardNum = cardNum.Insert(cardNum.Length-cardInt, " ");
                cardInt += 4;
            }
            return cardNum + " " + parameter.ToString();

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
