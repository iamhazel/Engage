using System;
using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Engage.Converters
{
    public class StringToTitleCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is string))
            {
                return value;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}