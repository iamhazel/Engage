using System;
using System.Globalization;
using Engage.ViewModels;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Windows.UI;

namespace Engage.Converters
{
    public class ChatMessageTypeToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ChatMessageType chatMessageType)
            {
                string resourceName = chatMessageType == ChatMessageType.Sent ? "TextFillColorInverse" : "TextFillColorPrimary";
                var resource = Application.Current.Resources[resourceName];

                if (resource is SolidColorBrush brush)
                {
                    return brush;
                }
                else if (resource is Color color)
                {
                    return new SolidColorBrush(color);
                }
                else if (resource is string colorString)
                {
                    Color parsedColor = Color.FromArgb(
                        byte.Parse(colorString.Substring(1, 2), NumberStyles.HexNumber),
                        byte.Parse(colorString.Substring(3, 2), NumberStyles.HexNumber),
                        byte.Parse(colorString.Substring(5, 2), NumberStyles.HexNumber),
                        byte.Parse(colorString.Substring(7, 2), NumberStyles.HexNumber)
                    );
                    return new SolidColorBrush(parsedColor);
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
