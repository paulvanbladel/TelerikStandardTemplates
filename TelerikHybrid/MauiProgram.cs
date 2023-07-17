using Microsoft.AspNetCore.Components.WebView.Maui;
using System.Globalization;
using Telerik.Blazor.Services;
using TelerikHybrid.Data;
using TelerikHybrid.Services;

namespace TelerikHybrid
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
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            // register the Telerik services
            builder.Services.AddTelerikBlazor();
            // register a custom localizer for the Telerik components, after registering the Telerik services
            builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(ResxLocalizer));
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddLocalization();

            var host = builder.Build();

            SetCulture(host);

            return host;
        }

        // based on https://github.com/pranavkm/LocSample
        static void SetCulture(MauiApp host)
        {
            // Cannot use JS interop outside the context of a component in MAUI
            // Refactor the below once the following issue is resolved: https://github.com/dotnet/maui/issues/5804
            //var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
            //var cultureName = await jsRuntime.InvokeAsync<string>("blazorCulture.get");
            string cultureName = null;

            if (cultureName != null)
            {
                var culture = new CultureInfo(cultureName);

                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }
    }
}