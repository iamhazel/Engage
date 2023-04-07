using System.Diagnostics;
using Engage.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// Engage.Views.SettingsPage.xaml.cs
namespace Engage.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel { get; } = new SettingsViewModel();

    public SettingsPage()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }

    private void OnSettingsServicesClick(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Engage.Views.Settings.SettingsServicesPage));
    }
}
