using Registr8;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;
using Registr8.Components.Android;

namespace Registr8
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<Utilites>();
            builder.Services.AddSingleton<Registr8.Interfaces.IFilePickerService, Registr8.Interfaces.PickerInterface>();
#if ANDROID
            builder.Services.AddSingleton<Registr8.Interfaces.IPlatformPickerService, PlatformPickerService>();
#endif
            builder.Services.AddBlazorBootstrap();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            Globals.Init();
            return builder.Build();
        }
    }
}
