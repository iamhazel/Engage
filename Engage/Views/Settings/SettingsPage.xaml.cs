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

    private void DebugButton_Click(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine($"SettingCards count: {ViewModel.SettingCards.Count}");
    }
}
