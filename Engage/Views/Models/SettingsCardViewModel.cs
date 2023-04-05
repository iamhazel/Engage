using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace EngageV2.Views.Models;

public class SettingsCardViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _cardTitle;
    public string CardTitle
    {
        get => _cardTitle;
        set
        {
            _cardTitle = value;
            OnPropertyChanged();
        }
    }

    private string _cardSubtitle;
    public string CardSubtitle
    {
        get => _cardSubtitle;
        set
        {
            _cardSubtitle = value;
            OnPropertyChanged();
        }
    }

    private SolidColorBrush _cardBackground;
    public SolidColorBrush CardBackground
    {
        get => _cardBackground;
        set
        {
            _cardBackground = value;
            OnPropertyChanged();
        }
    }

    private SolidColorBrush _cardBorderBrush;
    public SolidColorBrush CardBorderBrush
    {
        get => _cardBorderBrush;
        set
        {
            _cardBorderBrush = value;
            OnPropertyChanged();
        }
    }

    private Thickness _cardBorderThickness;
    public Thickness CardBorderThickness
    {
        get => _cardBorderThickness;
        set
        {
            _cardBorderThickness = value;
            OnPropertyChanged();
        }
    }

    private CornerRadius _cardCornerRadius;
    public CornerRadius CardCornerRadius
    {
        get => _cardCornerRadius;
        set
        {
            _cardCornerRadius = value;
            OnPropertyChanged();
        }
    }

    private double _cardWidth;
    public double CardWidth
    {
        get => _cardWidth;
        set
        {
            _cardWidth = value;
            OnPropertyChanged();
        }
    }

    private string _clickGlyph;
    public string ClickGlyph
    {
        get => _clickGlyph;
        set
        {
            _clickGlyph = value;
            OnPropertyChanged();
        }
    }

    private double _iconFontSize;
    public double IconFontSize
    {
        get => _iconFontSize;
        set
        {
            _iconFontSize = value;
            OnPropertyChanged();
        }
    }

    private string _iconGlyph;
    public string IconGlyph
    {
        get => _iconGlyph;
        set
        {
            _iconGlyph = value;
            OnPropertyChanged();
        }
    }

    private bool _toggleSwitchIsEnabled;
    public bool ToggleSwitchIsEnabled
    {
        get => _toggleSwitchIsEnabled;
        set
        {
            _toggleSwitchIsEnabled = value;
            OnPropertyChanged();
        }
    }

    private Thickness _toggleSwitchMargin;
    public Thickness ToggleSwitchMargin
    {
        get => _toggleSwitchMargin;
        set
        {
            _toggleSwitchMargin = value;
            OnPropertyChanged();
        }
    }

    private object _toggleSwitchOffContent;
    public object ToggleSwitchOffContent
    {
        get => _toggleSwitchOffContent;
        set
        {
            _toggleSwitchOffContent = value;
            OnPropertyChanged();
        }
    }

    private object _toggleSwitchOnContent;
    public object ToggleSwitchOnContent
    {
        get => _toggleSwitchOnContent;
        set
        {
            _toggleSwitchOnContent = value;
            OnPropertyChanged();
        }
    }

    private double _toggleSwitchWidth;
    public double ToggleSwitchWidth
    {
        get => _toggleSwitchWidth;
        set
        {
            _toggleSwitchWidth = value;
            OnPropertyChanged();
        }
    }
}
