// Engage.Converters.RoleToAlignmentConverter.cs
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace Engage.Converters
{
    public class RoleToAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ChatMessageType chatMessageType)
            {
                return chatMessageType == ChatMessageType.Sent ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            }

            return HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}