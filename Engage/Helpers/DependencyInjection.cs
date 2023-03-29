// Engage.DependencyInjection.cs
using Engage;
using Engage.ChatGPT;
using Engage.ViewModels;
using Engage.Views;
using Engage.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

public static class DependencyInjection
{
    // Extension method for adding application services to the service collection
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Add the ApiClient and Service objects to the service collection as singletons
        services.AddSingleton<IApiClient, ApiClient>();
        services.AddSingleton<IService, Service>();

        // Add the ChatViewModel and SettingsViewModel objects to the service collection as transient
        services.AddTransient<ChatViewModel>();
        services.AddTransient<SettingsViewModel>();

        // Add the MainWindow object to the service collection as a singleton
        services.AddSingleton<MainWindow>();

        // Add the HttpClient and logging services to the service collection
        services.AddHttpClient<IApiClient, ApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.openai.com/v1/");
        });
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information); // Make sure this is LogLevel.Information or lower
        });

        // Add helper services
        services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
    }
}
