// Engage.Views.SettingsPage.xaml.cs
using Engage.Helpers;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.ApplicationModel.DataTransfer;

namespace Engage.Views
{
    public sealed partial class SettingsPage : Page
    {
        private readonly SettingsViewModel _settingsViewModel;
        private readonly ILocalSettingsService _localSettingsService;

        public SettingsPage(SettingsViewModel settingsViewModel, ILocalSettingsService localSettingsService)
        {
            InitializeComponent();
            _settingsViewModel = settingsViewModel;
            _localSettingsService = localSettingsService;
            DataContext = _settingsViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the new API key and close the flyout
            string newApiKey = NewApiKeyTextBox.Text.Trim();

            if (ConfirmSaveToggle.IsOn)
            {
                SaveAPIKeyButton.IsEnabled = true;

                if (!string.IsNullOrEmpty(newApiKey))
                {
                    _settingsViewModel.SaveApiKey(newApiKey);

                    // Close the Flyout
                    if (UpdateApiKeyButton.Flyout is Flyout flyout)
                    {
                        flyout.Hide();
                    }

                    // Update the display field with the newly saved API key
                    ApiKeyTextBlock.Text = _settingsViewModel.ApiKey;
                }
            }
        }

        private async void ApiKeyCopy_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = _settingsViewModel.GetApiKey()?.ToString();
            if (!string.IsNullOrEmpty(apiKey))
            {
                var dataPackage = new DataPackage();
                dataPackage.SetText(apiKey);
                Clipboard.SetContent(dataPackage);

                var copiedText = await Clipboard.GetContent().GetTextAsync();
                if (copiedText == apiKey)
                {
                    // Success message
                }
                else
                {
                    // Error message
                }
            }
        }
    }
}
