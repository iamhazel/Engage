using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

// Engage.Models.SettingsCardViewModel.cs
namespace Engage.Models;

public class SettingsCardViewModel
{
    public string CardTitle { get; set; } = "Default Title";
    public string CardSubtitle { get; set; } = "Default subtitle";
    public SolidColorBrush CardBackground { get; set; } = (SolidColorBrush)Application.Current.Resources["SystemControlBackgroundAltHighBrush"];
    public SolidColorBrush CardBorderBrush { get; set; } = (SolidColorBrush)Application.Current.Resources["SystemControlForegroundBaseMediumLowBrush"];
    public string ClickGlyph { get; set; } = "\uE76C";
    public double IconFontSize { get; set; } = 24;
    public string IconGlyph { get; set; } = "\uE001";
    public object QuickControl { get; set; }
}