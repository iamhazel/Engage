// Engage.Views.MainWindow.xaml.cs
using Engage.ChatGPT;
using Engage.Helpers;
using Engage.ViewModels;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Core;

namespace Engage.Views
{
    // This is the code-behind for the main window of the application
    public sealed partial class MainWindow : Window
    {
        // Private fields for the chat service and settings view model
        private readonly IService _chatGPTService;
        private readonly SettingsViewModel _settingsViewModel;
        private ILocalSettingsService _localSettingService;

        // Constructor that takes an IApiClient and SettingsViewModel
        public MainWindow(IApiClient apiClient, SettingsViewModel settingsViewModel)
        {
            try
            {
                // Initialize window and set main content to home page
                InitializeComponent();
                MainFrame.Content = new HomePage();

                // Set up title bar
                this.SystemBackdrop = new MicaBackdrop();
                this.ExtendsContentIntoTitleBar = true;
                this.SetTitleBar(AppTitleBar);

                // Initialize chat service using the provided API client
                _chatGPTService = new Service(apiClient);

                // Store the injected SettingsViewModel
                _settingsViewModel = settingsViewModel;

                // Register event handlers for navigation view
                MainNavigationView.SelectionChanged += MainNavigationView_SelectionChanged;
                MainNavigationView.ItemInvoked += MainNavigationView_SettingsInvoked;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during initialization
                Debug.WriteLine($"Error initializing main window: {ex}");
                throw;
            }
        }

        // Event handler for when a new item is selected in the main navigation view
        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                // Get the selected item, extract its tag property, and store it in a string variable
                if (args.SelectedItem is NavigationViewItem item)
                {
                    string selectedItemTag = item.Tag.ToString();

                    // Show the appropriate page based on the selected item tag
                    switch (selectedItemTag)
                    {
                        case "Home":
                            MainFrame.Content = new HomePage();
                            MainNavigationView.SelectedItem = null;
                            break;
                        case "Chat":
                            MainFrame.Content = new ChatPage(_chatGPTService);
                            MainNavigationView.SelectedItem = null;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during page navigation
                Debug.WriteLine($"Error changing main navigation selection: {ex}");
                throw;
            }
        }

        // Event handler for when the settings button is clicked in the main navigation view
        private void MainNavigationView_SettingsInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                try
                {
                    // Show the settings page, passing in the settings view model
                    MainFrame.Content = new SettingsPage(_settingsViewModel, _localSettingService);
                    MainNavigationView.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during page navigation
                    Debug.WriteLine($"Error loading settings page: {ex}");
                    throw;
                }
            }
        }
    }
}
