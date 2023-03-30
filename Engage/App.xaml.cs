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
        public readonly IServiceProvider _serviceProvider;
        public ChatViewModel ChatViewModel { get; }

        // Constructor for the application class
        public App()
        {
            InitializeComponent();

            // Set up the dependency injection container
            _serviceProvider = ConfigureServices();
            ChatViewModel = _serviceProvider.GetRequiredService<ChatViewModel>();
        }

        // Method for setting up the dependency injection container
        private IServiceProvider ConfigureServices()
        {
            // Create a new ServiceCollection to hold the registered services
            var services = new ServiceCollection();

            // Register the application services with the container using the AddApplicationServices extension method
            services.AddApplicationServices();

            // Build the service provider from the registered services
            return services.BuildServiceProvider();
        }

        // Method that gets called when the application is launched
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Get the required services from the dependency injection container
            var localSettingService = _serviceProvider.GetRequiredService<ILocalSettingsService>();
            var apiClient = _serviceProvider.GetRequiredService<IApiClient>();
            var settingsViewModel = _serviceProvider.GetRequiredService<SettingsViewModel>();

            // Create a new MainWindow object with the required services injected into it
            var window = new MainWindow(apiClient, settingsViewModel);

            // Show the window
            window.Activate();
        }

        // Method that gets called when the application is exiting
        private void OnExit(object sender, RoutedEventArgs e)
        {
            // Get the required services from the dependency injection container
            var httpClient = _serviceProvider.GetRequiredService<HttpClient>();
            httpClient.Dispose();

            var localSettingService = _serviceProvider.GetRequiredService<ILocalSettingsService>();
            var logger = _serviceProvider.GetRequiredService<ILogger<ApiClient>>();

            // Create a new ApiClient object with the required services injected into it
            var apiClient = new ApiClient(httpClient, localSettingService, logger);
        }
    }
}
