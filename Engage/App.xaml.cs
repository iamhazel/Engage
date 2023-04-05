using Microsoft.UI.Xaml;
using EngageV2.Views;

namespace EngageV2;

public partial class App : Application
{
    private Window m_window;

    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        m_window.Activate();
    }
}
