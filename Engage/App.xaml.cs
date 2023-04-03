// Engage.App.xaml.cs
using Engage.OpenAI;
using Engage.Helpers;
using Engage.ViewModels;
using Engage.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using System;
using System.Net.Http;

namespace Engage
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }
        public ILocalSettingsService LocalSettingService { get; }

        public ChatViewModel ChatViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }

        // Constructor for the application class
        public App()
        {
            InitializeComponent();

            // Set up the dependency injection container
            ServiceProvider = ConfigureServices();
            ChatViewModel = ServiceProvider.GetRequiredService<ChatViewModel>();
            SettingsViewModel = ServiceProvider.GetRequiredService<SettingsViewModel>();
            LocalSettingService = ServiceProvider.GetRequiredService<ILocalSettingsService>();
        }

        // Method for setting up the dependency injection container
        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();
            return services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var window = new MainWindow(ServiceProvider);
            window.Activate();
        }
    }
}