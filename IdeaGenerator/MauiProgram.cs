using IdeaGenerator.Repositories;
using IdeaGenerator.Utils;
using IdeaGenerator.ViewModels;

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
        .RegisterRepos()
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

    public static MauiAppBuilder RegisterRepos(this MauiAppBuilder appBuilder)
    {
        string dbPath = FileAccessHelper.GetLocalFilePath("People.db3");
        appBuilder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<AgentRepository>(s, dbPath));
        appBuilder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<EngineRepository>(s, dbPath));

        return appBuilder;
    }
}
