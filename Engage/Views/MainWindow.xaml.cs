// Engage.Views.MainWindow.xaml.cs
using System;
using System.Diagnostics;
using Engage.ChatGPT;
using Engage.Helpers;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Engage.Views
{
    public sealed partial class MainWindow : Window
    {
        private readonly IChatService _chatService;
        private readonly SettingsViewModel _settingsViewModel;
        private ILocalSettingsService _localSettingService;
        private readonly ChatViewModel _chatViewModel; // Add this line

        public MainWindow(IApiClient apiClient, SettingsViewModel settingsViewModel)
        {
            try
            {
                InitializeComponent();
                MainFrame.Content = new HomePage();

                this.SystemBackdrop = new MicaBackdrop();
                this.ExtendsContentIntoTitleBar = true;
                this.SetTitleBar(AppTitleBar);

                _chatService = new ChatService(apiClient);
                _settingsViewModel = settingsViewModel;

                _chatViewModel = new ChatViewModel(_chatService); // Initialize the ChatViewModel instance

                MainNavigationView.SelectionChanged += MainNavigationView_SelectionChanged;
                MainNavigationView.ItemInvoked += MainNavigationView_SettingsInvoked;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing main window: {ex}");
                throw;
            }
        }

        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem item)
            {
                string selectedItemTag = item.Tag.ToString();

                switch (selectedItemTag)
                {
                    case "Home":
                        MainFrame.Content = new HomePage();
                        MainNavigationView.SelectedItem = null;
                        break;
                    case "Chat":
                        MainFrame.Content = new ChatPage(_chatViewModel); // Pass the ChatViewModel instance
                        MainNavigationView.SelectedItem = null;
                        break;
                }
            }
        }

        private void MainNavigationView_SettingsInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                try
                {
                    MainFrame.Content = new SettingsPage(_settingsViewModel, _localSettingService);
                    MainNavigationView.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading settings page: {ex}");
                    throw;
                }
            }
        }
    }
}