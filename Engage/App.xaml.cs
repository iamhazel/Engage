﻿using Microsoft.UI.Xaml;
using Engage.Views;

namespace Engage;

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
