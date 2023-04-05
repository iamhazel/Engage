using System;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Dispatching;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace EngageV2.Views;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        this.SystemBackdrop = new MicaBackdrop();
        this.ExtendsContentIntoTitleBar = true;
        this.SetTitleBar(AppTitleBar);

        MainFrame.Navigate(typeof(HomePage));
    }

    private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            MainFrame.Navigate(typeof(SettingsPage));
        }
        else
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "Home":
                    MainFrame.Navigate(typeof(HomePage));
                    break;
                case "Chat":
                    MainFrame.Navigate(typeof(ChatPage));
                    break;
            }
        }
    }
    private void MainNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (MainFrame.CanGoBack)
        {
            MainFrame.GoBack();
        }
    }
}
