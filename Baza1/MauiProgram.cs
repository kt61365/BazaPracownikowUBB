using Baza1.Services;
using Microsoft.Extensions.Logging;

namespace Baza1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Rejestracja serwisu bazy danych
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DeletePage>();

        return builder.Build();
    }
}