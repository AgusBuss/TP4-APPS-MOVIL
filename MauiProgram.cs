using Microsoft.Extensions.Logging;
using TP4___TRANI.Services;

namespace TP4___TRANI
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

            // Registrar HttpClient
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://fakestoreapi.com/")
            });

            // Registrar ProductService
            builder.Services.AddScoped<ProductService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}