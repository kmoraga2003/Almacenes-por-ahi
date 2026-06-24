using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<AppDataService>();

        return builder.Build();
    }
}
