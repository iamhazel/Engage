using Windows.Storage;

namespace Engage.Helpers
{
    public class LocalSettingsService : ILocalSettingsService
    {
        public string GetSetting(string key)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            return localSettings.Values[key] as string;
        }

        public void SetSetting(string key, string value)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values[key] = value;
        }
    }

}
