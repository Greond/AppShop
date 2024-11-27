using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Converters
{
     class ItemTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null || parameter.ToString() == string.Empty)
            {
                return null;
            }
            IEnumerable<string> result = new List<string>();
            if (parameter.ToString().Length > 2)
            {
                char dilimeter = parameter.ToString()[0];
                char additionallyChar = parameter.ToString()[2];
                result = value.ToString().Split(dilimeter).Select(s => additionallyChar + s);
            }
            else if (parameter.ToString().Length > 0)
            {
                char dilimeter = parameter.ToString()[0];
                result = value.ToString().Split(dilimeter);
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
