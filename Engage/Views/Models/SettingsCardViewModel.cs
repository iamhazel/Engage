using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

// Engage.Views.Models.SettingsCardViewModel.cs
namespace Engage.Views.Models;

public class SettingsCardViewModel
{
    public string CardTitle { get; set; } = "Default Title";
    public string CardSubtitle { get; set; } = "Default subtitle";
    public SolidColorBrush CardBackground { get; set; } = new SolidColorBrush(Colors.LightBlue);
    public SolidColorBrush CardBorderBrush { get; set; }
    public string ClickGlyph { get; set; } = "\uE76C";
    public double IconFontSize { get; set; } = 24;
    public string IconGlyph { get; set; } = "\uE001";
}