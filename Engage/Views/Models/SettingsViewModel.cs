using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Engage.Views.Models.SettingsViewModel.cs
namespace Engage.Views.Models
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

            // Add your different settings cards here
            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Services",
                CardSubtitle = "Add, update, or remove API services.",
                IconGlyph = "\uE945",
                IconFontSize = 24,
            });

            SettingCards.Add(new SettingsCardViewModel
            {
                CardTitle = "Appearance",
                CardSubtitle = "Change the look and feel of the app.",
                IconGlyph = "\uE790",
                IconFontSize = 24,
            });
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
