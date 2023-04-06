using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace Engage.Views.Models
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private double _cardWidth;
        public double CardWidth
        {
            get { return _cardWidth; }
            set { _cardWidth = value; OnPropertyChanged(); }
        }

        private Brush _cardBackground = (Brush)Application.Current.Resources["SystemControlBackgroundAccentBrush"];
        public Brush CardBackground
        {
            get { return _cardBackground; }
            set { _cardBackground = value; OnPropertyChanged(); }
        }

        private Brush _cardBorderBrush = new SolidColorBrush((Windows.UI.Color)Application.Current.Resources["SystemBaseMediumColor"]);
        public Brush CardBorderBrush
        {
            get { return _cardBorderBrush; }
            set { _cardBorderBrush = value; OnPropertyChanged(); }
        }

        private Thickness _cardBorderThickness = new Thickness(1);
        public Thickness CardBorderThickness
        {
            get { return _cardBorderThickness; }
            set { _cardBorderThickness = value; OnPropertyChanged(); }
        }

        private CornerRadius _cardCornerRadius = new CornerRadius(4);
        public CornerRadius CardCornerRadius
        {
            get { return _cardCornerRadius; }
            set { _cardCornerRadius = value; OnPropertyChanged(); }
        }

        private string _iconGlyph = "\uE713";
        public string IconGlyph
        {
            get { return _iconGlyph; }
            set { _iconGlyph = value; OnPropertyChanged(); }
        }

        private double _iconFontSize = 16;
        public double IconFontSize
        {
            get { return _iconFontSize; }
            set { _iconFontSize = value; OnPropertyChanged(); }
        }

        private string _cardTitle = "Display Settings";
        public string CardTitle
        {
            get { return _cardTitle; }
            set { _cardTitle = value; OnPropertyChanged(); }
        }

        private string _cardSubtitle = "Adjust the display settings";
        public string CardSubtitle
        {
            get { return _cardSubtitle; }
            set { _cardSubtitle = value; OnPropertyChanged(); }
        }

        private double _toggleSwitchWidth;
        public double ToggleSwitchWidth
        {
            get { return _toggleSwitchWidth; }
            set { _toggleSwitchWidth = value; OnPropertyChanged(); }
        }

        private Thickness _toggleSwitchMargin = new Thickness(6, 0, 0, 0);
        public Thickness ToggleSwitchMargin
        {
            get { return _toggleSwitchMargin; }
            set { _toggleSwitchMargin = value; OnPropertyChanged(); }
        }

        private string _toggleSwitchOffContent = "";
        public string ToggleSwitchOffContent
        {
            get { return _toggleSwitchOffContent; }
            set { _toggleSwitchOffContent = value; OnPropertyChanged(); }
        }

        private string _toggleSwitchOnContent = "";
        public string ToggleSwitchOnContent
        {
            get { return _toggleSwitchOnContent; }
            set { _toggleSwitchOnContent = value; OnPropertyChanged(); }
        }

        private bool _toggleSwitchIsEnabled;
        public bool ToggleSwitchIsEnabled
        {
            get { return _toggleSwitchIsEnabled; }
            set { _toggleSwitchIsEnabled = value; OnPropertyChanged(); }
        }

        private string _clickGlyph = "\uE76C";
        public string ClickGlyph
        {
            get { return _clickGlyph; }
            set { _clickGlyph = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SettingsCardViewModel> _settingCards;
        public ObservableCollection<SettingsCardViewModel> SettingCards
        {
            get => _settingCards;
            set
            {
                _settingCards = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel()
        {
            SettingCards = new ObservableCollection<SettingsCardViewModel>();

            // Add your different settings cards here
            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Services",
                CardSubtitle = "Add or remove API services.",
                IconGlyph = "\uE945",
                IconFontSize = 24,
                CardCornerRadius = new CornerRadius(4),
                CardBorderThickness = new Thickness(1),
                ToggleSwitchIsEnabled = true,
                ToggleSwitchMargin = new Thickness(6, 0, 0, 0),
                ToggleSwitchOnContent = "",
                ToggleSwitchOffContent = "",
                ClickGlyph = "\uE76C"
            });

            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Appearance",
                CardSubtitle = "Change colors and themes.",
                IconGlyph = "\uE790", // A sample icon glyph (paintbrush)
                IconFontSize = 24,
                CardCornerRadius = new CornerRadius(4),
                CardBorderThickness = new Thickness(1),
                ToggleSwitchIsEnabled = true,
                ToggleSwitchMargin = new Thickness(6, 0, 0, 0),
                ToggleSwitchOnContent = "",
                ToggleSwitchOffContent = "",
                ClickGlyph = "\uE76C"
            });
            // ...
        }

        // Should eventually implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
