namespace Engage.Helpers
{
    public interface ILocalSettingsService
    {
        string GetSetting(string key);
        void SetSetting(string key, string value);
    }
}
