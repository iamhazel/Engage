// Engage.ViewModels.SettingsViewModel.cs
using Engage.Helpers;
using Windows.Storage;

namespace Engage.ViewModels
{
    public class SettingsViewModel
    {
        private readonly ILocalSettingsService _localSettingsService;

        public SettingsViewModel(ILocalSettingsService localSettingsService)
        {
            _localSettingsService = localSettingsService;
        }

        public string ApiKey { get => _localSettingsService.GetSetting("OpenAIKey"); }

        // Save the API key to LocalSettings
        public void SaveApiKey(string apiKey)
        {
            _localSettingsService.SetSetting("OpenAIKey", apiKey);
        }

        // Retrieve the API key from LocalSettings
        public string GetApiKey()
        {
            if (_localSettingsService.GetSetting("OpenAIKey") != null)
            {
                return _localSettingsService.GetSetting("OpenAIKey");
            }
            else
            {
                return null;
            }
        }
    }
}
