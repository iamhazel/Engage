using System.ComponentModel;
using System.Runtime.CompilerServices;
using EngageV2.Views.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

namespace EngageV2.Views.Controls
{
    public partial class SettingsCardControl : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty CardWidthProperty =
            DependencyProperty.Register("CardWidth", typeof(double), typeof(SettingsCardControl), new PropertyMetadata(800.0));

        public double CardWidth
        {
            get { return (double)GetValue(CardWidthProperty); }
            set { SetValue(CardWidthProperty, value); }
        }

        public static readonly DependencyProperty CardBackgroundProperty =
            DependencyProperty.Register("CardBackground", typeof(Brush), typeof(SettingsCardControl), new PropertyMetadata(null));

        public Brush CardBackground
        {
            get { return (Brush)GetValue(CardBackgroundProperty); }
            set { SetValue(CardBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CardBorderBrushProperty =
            DependencyProperty.Register("CardBorderBrush", typeof(Brush), typeof(SettingsCardControl), new PropertyMetadata(null));

        public Brush CardBorderBrush
        {
            get { return (Brush)GetValue(CardBorderBrushProperty); }
            set { SetValue(CardBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty CardBorderThicknessProperty =
            DependencyProperty.Register("CardBorderThickness", typeof(Thickness), typeof(SettingsCardControl), new PropertyMetadata(new Thickness(1)));

        public Thickness CardBorderThickness
        {
            get { return (Thickness)GetValue(CardBorderThicknessProperty); }
            set { SetValue(CardBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty CardCornerRadiusProperty =
            DependencyProperty.Register("CardCornerRadius", typeof(CornerRadius), typeof(SettingsCardControl), new PropertyMetadata(new CornerRadius(4)));

        public CornerRadius CardCornerRadius
        {
            get { return (CornerRadius)GetValue(CardCornerRadiusProperty); }
            set { SetValue(CardCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty IconGlyphProperty =
            DependencyProperty.Register("IconGlyph", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }

        public static readonly DependencyProperty IconFontSizeProperty =
            DependencyProperty.Register("IconFontSize", typeof(double), typeof(SettingsCardControl), new PropertyMetadata(24.0));

        public double IconFontSize
        {
            get { return (double)GetValue(IconFontSizeProperty); }
            set { SetValue(IconFontSizeProperty, value); }
        }

        public static readonly DependencyProperty CardTitleProperty =
            DependencyProperty.Register("CardTitle", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string CardTitle
        {
            get { return (string)GetValue(CardTitleProperty); }
            set { SetValue(CardTitleProperty, value); }
        }

        public static readonly DependencyProperty CardSubtitleProperty =
            DependencyProperty.Register("CardSubtitle", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string CardSubtitle
        {
            get { return (string)GetValue(CardSubtitleProperty); }
            set { SetValue(CardSubtitleProperty, value); OnPropertyChanged(); }
        }

        public static readonly DependencyProperty ToggleSwitchWidthProperty =
            DependencyProperty.Register("ToggleSwitchWidth", typeof(double), typeof(SettingsCardControl), new PropertyMetadata(110.0));

        public double ToggleSwitchWidth
        {
            get { return (double)GetValue(ToggleSwitchWidthProperty); }
            set { SetValue(ToggleSwitchWidthProperty, value); }
        }

        public static readonly DependencyProperty ToggleSwitchMarginProperty =
            DependencyProperty.Register("ToggleSwitchMargin", typeof(Thickness), typeof(SettingsCardControl), new PropertyMetadata(new Thickness(6, 0, 0, 0)));

        public Thickness ToggleSwitchMargin
        {
            get { return (Thickness)GetValue(ToggleSwitchMarginProperty); }
            set { SetValue(ToggleSwitchMarginProperty, value); }
        }

        public static readonly DependencyProperty ToggleSwitchOnContentProperty =
            DependencyProperty.Register("ToggleSwitchOnContent", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string ToggleSwitchOnContent
        {
            get { return (string)GetValue(ToggleSwitchOnContentProperty); }
            set { SetValue(ToggleSwitchOnContentProperty, value); }
        }

        public static readonly DependencyProperty ToggleSwitchOffContentProperty =
            DependencyProperty.Register("ToggleSwitchOffContent", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string ToggleSwitchOffContent
        {
            get { return (string)GetValue(ToggleSwitchOffContentProperty); }
            set { SetValue(ToggleSwitchOffContentProperty, value); }
        }

        public static readonly DependencyProperty ToggleSwitchIsEnabledProperty =
            DependencyProperty.Register("ToggleSwitchIsEnabled", typeof(bool), typeof(SettingsCardControl), new PropertyMetadata(true));

        public bool ToggleSwitchIsEnabled
        {
            get { return (bool)GetValue(ToggleSwitchIsEnabledProperty); }
            set { SetValue(ToggleSwitchIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ClickGlyphProperty =
            DependencyProperty.Register("ClickGlyph", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string ClickGlyph
        {
            get { return (string)GetValue(ClickGlyphProperty); }
            set { SetValue(ClickGlyphProperty, value); }
        }

        public SettingsCardControl()
        {
            InitializeComponent();
            SettingsCard.PointerEntered += SettingsCard_PointerEntered;
            SettingsCard.PointerExited += SettingsCard_PointerExited;
        }

        public SettingsCardControl(SettingsViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }

        private void SettingsCard_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PointerOver", true);
        }

        private void SettingsCard_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}