// Engage.Views.MainWindow.xaml.cs
using System;
using System.Diagnostics;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Engage.Views.Controls;
using Microsoft.UI.Xaml.Media;
using Engage.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Engage.Views
{
    public sealed partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SignalManager _signalManager;
        public Frame PublicSignalContainer => GlobalSignalContainer;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _signalManager = serviceProvider.GetService<SignalManager>();
            MainFrame.Content = new HomePage();

            this.SystemBackdrop = new MicaBackdrop();
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);

            MainNavigationView.SelectionChanged += MainNavigationView_SelectionChanged;
            MainNavigationView.ItemInvoked += MainNavigationView_SettingsInvoked;
        }

        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var app = Application.Current as App;

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
                        MainFrame.Content = new ChatPage(app.ChatViewModel, this); // Pass 'this' as the second argument
                        MainNavigationView.SelectedItem = null;
                        break;
                    case "Layouts":
                        MainFrame.Content = new LayoutsPage(); // Pass 'this' as the second argument
                        MainNavigationView.SelectedItem = null;
                        break;
                }
            }
        }

        private void MainNavigationView_SettingsInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var app = Application.Current as App;

            if (args.IsSettingsInvoked)
            {
                MainFrame.Content = new SettingsPage(app.SettingsViewModel, app.LocalSettingService);
                MainNavigationView.SelectedItem = null;
            }
        }

        private void DevSendSignal_Click(object sender, RoutedEventArgs e)
        {
            // get an instance of IServiceProvider from the app's service provider
            var serviceProvider = (Application.Current as App).ServiceProvider;
            var signalManager = serviceProvider.GetService<SignalManager>();

            // use the signal manager to show a signal
            signalManager.ShowSignal("Title", "Message", Signal.SignalType.Success);

        }
    }
}
