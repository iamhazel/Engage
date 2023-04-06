using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

// Engage.Views.Controls.SettingsCardControl.xaml.cs
namespace Engage.Controls
{
    public partial class SettingsCardControl : UserControl, INotifyPropertyChanged
    {
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


        public static readonly DependencyProperty IconGlyphProperty =
            DependencyProperty.Register("IconGlyph", typeof(string), typeof(SettingsCardControl), new PropertyMetadata(null));

        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }


        public static readonly DependencyProperty IconFontSizeProperty =
            DependencyProperty.Register("IconFontSize", typeof(double), typeof(SettingsCardControl), new PropertyMetadata(null));

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
            set { SetValue(CardSubtitleProperty, value); }
        }


        public static readonly DependencyProperty QuickControlProperty =
            DependencyProperty.Register("QuickControl", typeof(object), typeof(SettingsCardControl), new PropertyMetadata(null));

        public object QuickControl
        {
            get { return (object)GetValue(QuickControlProperty); }
            set { SetValue(QuickControlProperty, value); }
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
        }


        protected override void OnPointerEntered(PointerRoutedEventArgs e)
        {
            base.OnPointerEntered(e);
            VisualStateManager.GoToState(this, "PointerOver", true);
        }


        protected override void OnPointerExited(PointerRoutedEventArgs e)
        {
            base.OnPointerExited(e);
            VisualStateManager.GoToState(this, "Normal", true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}