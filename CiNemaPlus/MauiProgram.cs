using CiNemaPlus.Services;
using Microsoft.Extensions.Logging;

namespace CiNemaPlus
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
            builder.Services.AddTransient<MovieViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddHttpClient<MoviesApiService>(c => 
            {
                c.BaseAddress = new Uri(Constants.BaseUrl);

                c.Timeout = TimeSpan.FromSeconds(15);
            });

            return builder.Build();
        }
    }
}
