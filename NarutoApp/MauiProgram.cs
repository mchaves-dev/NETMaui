using Microsoft.Extensions.Logging;
using NarutoApp.Data.Repositories;
using NarutoApp.Data.Repositories.Contracts;
using NarutoApp.ViewModels;

namespace NarutoApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient(ApiSettings.ApiName, x =>
            {
                x.BaseAddress = new Uri(ApiSettings.ApiUrl);
            });

            builder.Services.AddScoped<CharactersPageViewModel>();
            builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

            return builder.Build();
        }
    }
}
