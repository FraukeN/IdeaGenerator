using IdeaGenerator.ViewModels;
using Microsoft.Extensions.Logging;

namespace IdeaGenerator;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
        => MauiApp
        .CreateBuilder()
        .UseMauiApp<App>()
        .ConfigureFonts(
            fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
        .RegisterViewModels()
        .RegisterViews()
        .Build();

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<MainViewModel>();

        return appBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddTransient<MainView>();

        return appBuilder;
    }
}
