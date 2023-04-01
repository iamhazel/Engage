// Engage.DependencyInjection.cs
using Engage;
using Engage.OpenAI;
using Engage.ViewModels;
using Engage.Views;
using Engage.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

public static class DependencyInjection
{
    // Extension method for adding application services to the service collection
    public static void AddApplicationServices(this ServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<Func<Frame>>(sp => () => ((MainWindow)sp.GetService<MainWindow>()).PublicSignalContainer);

        services.AddTransient<SettingsViewModel>();
        services.AddTransient<ChatViewModel>();
        services.AddTransient<ChatTabViewModel>();
        services.AddSingleton<SignalManager>();

        services.AddSingleton<IChatService, ChatService>();
        services.AddSingleton<IApiClient, ApiClient>();
        services.AddHttpClient<IApiClient, ApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.openai.com/v1/");
        });
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });
        services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
    }
}
