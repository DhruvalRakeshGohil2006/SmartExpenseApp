using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using The49.Maui.BottomSheet;
using Syncfusion.Maui.Toolkit.Hosting;
using SmartExpenseApp.Data;
using SmartExpenseApp.Views;

namespace SmartExpenseApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .UseBottomSheet()
                // Initialize the .NET MAUI Community Toolkit
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<HomeScreen>();
            builder.Services.AddTransient<HomeScreen>();
            builder.Services.AddSingleton<SmartExpenseAppDatabase>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
