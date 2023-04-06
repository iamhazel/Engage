using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;

// Engage.Models.SettingsViewModel.cs
namespace Engage.Models
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "General",
                CardSubtitle = "Change general settings.",
                IconGlyph = "\uE713",
                IconFontSize = 24
            });

            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Services",
                CardSubtitle = "Add, update, or remove API services.",
                IconGlyph = "\uE945",
                IconFontSize = 24,
                QuickControl = new ToggleSwitch { OnContent = "Connected", OffContent = "No Connections", IsEnabled = false, IsOn = true }
            });

            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Appearance",
                CardSubtitle = "Change the look and feel of the app.",
                IconGlyph = "\uE790",
                IconFontSize = 24,
                QuickControl = new ComboBox { Items = { "System Default", "Dark Mode", "Light Mode" }, SelectedIndex = 0 }
            });
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
